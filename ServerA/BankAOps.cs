using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Messaging;
using ServerA;
using System.Collections.Generic;

namespace BankA
{
    public class BankAOps : IBankAOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["ebanking"].ToString();
        
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void buyStock(int client_id, double amount, int company_id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            double stockPrice = getCompanyStockPrice(company_id);
            try
            {
                string date = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                conn.Open();
                string sqlcmd = "INSERT INTO Stock Values(" + client_id + ", 'unexecuted', 'buy', " + (amount * stockPrice) + ", " + amount + ", '" + date + "', null, " + company_id + ")";
                Console.WriteLine(sqlcmd);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    int size = getOrders().Count;
                    OperationContext.Current.SetTransactionComplete();
                    MessageQueue messageQueue = null;
                    if (MessageQueue.Exists(@".\Private$\supervisor"))
                    {
                        messageQueue = new MessageQueue(@".\Private$\supervisor");
                        if (messageQueue.Transactional == true)
                        {
                            using (MessageQueueTransaction trans = new MessageQueueTransaction())
                            {
                                string send = "+" + size + "+" + company_id.ToString() + "+" + "buy+" + amount + "+" + date.ToString() + "+" + client_id.ToString() + "+" + (stockPrice*amount).ToString() + "+";
                                trans.Begin();
                                messageQueue.Send(send, trans);
                                trans.Commit();
                            }
                        }
                    }
                    else
                        messageQueue.Send("First ever Message is sent to MSMQ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void sellStock(int client_id, double amount, int company_id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            double stockPrice = getCompanyStockPrice(company_id);
            try
            {
                string date = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                conn.Open();
                string sqlcmd = "INSERT INTO Stock Values(" + client_id + ", 'unexecuted', 'sell', " + (amount * stockPrice) + ", " + amount + ", '" + date + "', null, " + company_id + " )";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    int size = getOrders().Count;
                    OperationContext.Current.SetTransactionComplete();
                    MessageQueue messageQueue = null;
                    if (MessageQueue.Exists(@".\Private$\supervisor"))
                    {
                        messageQueue = new MessageQueue(@".\Private$\supervisor");
                        if (messageQueue.Transactional == true)
                        {
                            using (MessageQueueTransaction trans = new MessageQueueTransaction())
                            {
                                string send = "+" + size + "+" + company_id.ToString() + "+" + "sell+" + amount + "+" + date.ToString() + "+" + client_id.ToString() + "+" + (stockPrice * amount).ToString() + "+";
                                trans.Begin();
                                messageQueue.Send(send, trans);
                                trans.Commit();
                            }
                        }
                    }
                    else
                        messageQueue.Send("First ever Message is sent to MSMQ");
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public string checkOrder(int order_id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string state;
            try
            {
                conn.Open();
                string sqlcmd = "SELECT state FROM Stock WHERE id=" + order_id.ToString();
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                state = (string)cmd.ExecuteScalar();
            }
            catch
            {
                state = "error";
            }
            finally
            {
                conn.Close();
            }
            return state;
        }

        public List<Order> getUnexecutedOrders()
        {
            {
                List<Order> orderList = new List<Order>();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT* FROM Stock WHERE state = @unexecuted";
                    cmd.Parameters.AddWithValue("unexecuted", "unexecuted");
                    cmd.CommandTimeout = 0;
                    using (SqlDataReader results = cmd.ExecuteReader())
                    {
                        while(results.Read())
                        {
                            Order order = new Order();
                            order.Id = Convert.ToInt32(results["id"]);
                            order.Client_id = Convert.ToInt32(results.GetValue(1));
                            order.State = (string)results.GetValue(2);
                            order.Type = (string)results.GetValue(3);
                            order.Value = Convert.ToInt32(results.GetValue(4));
                            order.Quantity = Convert.ToInt32(results.GetValue(5));
                            order.Creation_date = (DateTime)results.GetValue(6);
                            order.Company_id = Convert.ToInt32(results.GetValue(8));
                            orderList.Add(order);

                            Console.WriteLine(order.ToString());
                        }
                        results.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return orderList;
                }
                finally
                {
                    conn.Close();
                }
                return orderList;
            }
        }

        public List<Order> getClientHistory(int client_id)
        {
            {
                List<Order> orderList = new List<Order>();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    string sqlcmd = "SELECT * FROM Stock WHERE client_id =" + client_id;
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    using (SqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Order order = new Order();
                            order.Id = Convert.ToInt32(results["id"]);
                            order.Client_id = Convert.ToInt32(results.GetValue(1));
                            order.State = (string)results.GetValue(2);
                            order.Type = (string)results.GetValue(3);
                            order.Value = Convert.ToInt32(results.GetValue(4));
                            order.Quantity = Convert.ToInt32(results.GetValue(5));
                            order.Creation_date = (DateTime)results.GetValue(6);
                            order.Company_id = Convert.ToInt32(results.GetValue(8));
                            if (!results.IsDBNull(7))
                            {
                                order.Execution_date = (DateTime)results.GetValue(7);
                            }
                            orderList.Add(order);
                        }
                    }
                }
                catch
                {
                    return orderList;
                }
                finally
                {
                    conn.Close();
                }
                return orderList;
            }
        }

        public List<Company> getCompanies()
        {
            {
                List<Company> companyList = new List<Company>();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    string sqlcmd = "SELECT * FROM Company";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    using (SqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Company company = new Company();
                            company.Id = (int)results.GetValue(0);
                            company.Name = (string)results.GetValue(1);
                            company.CurrentStockPrice = (decimal)results.GetValue(2);
                            companyList.Add(company);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return companyList;
                }
                finally
                {
                    conn.Close();
                }
                return companyList;
            }
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void updateStock(int order_id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "UPDATE Stock SET state = 'executed', execution_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +  "' WHERE id =" + order_id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public double getCompanyStockPrice(int company_id)
        {
            double amount;

            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "SELECT currentStockPrice FROM Company WHERE id = " + company_id.ToString();
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                amount = Convert.ToDouble((decimal)cmd.ExecuteScalar());
            }
            catch
            {
                amount = 0;
            }
            finally
            {
                conn.Close();
            }
            return amount;
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void editStock(Order order)
        {
            int rows;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "UPDATE Stock SET type = '" + order.Type + "' WHERE id= " + order.Id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            catch (Exception exc)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void deleteOrder(int order_id)
        {
            int rows;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "DELETE FROM Stock WHERE id= " + order_id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            catch(Exception exc)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public Cliente getClient(int client_id)
        {
            Cliente client = new Cliente();

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Client WHERE id = " + client_id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    if(results.Read())
                    {
                        client.Name = (string) results.GetValue(1);
                        client.Email = (string) results.GetValue(2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Cliente();
            }
            finally
            {
                conn.Close();
            }
            return client;
        }

        public List<Cliente> getClients()
        {
            {
                List<Cliente> clientList = new List<Cliente>();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    string sqlcmd = "SELECT * FROM Client";
                    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                    using (SqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Cliente client = new Cliente();
                            client.Id = (int)results.GetValue(0);
                            client.Name = (string)results.GetValue(1);
                            client.Email = (string)results.GetValue(2);
                            clientList.Add(client);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return clientList;
                }
                finally
                {
                    conn.Close();
                }
                return clientList;
            }
        }

        public Company getCompany(int company_id)
        {
            Company company = new Company();

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM Company WHERE id = " + company_id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                using (SqlDataReader results = cmd.ExecuteReader())
                {
                    if (results.Read())
                    {
                        company.Id = (int)results.GetValue(0);
                        company.Name = (string)results.GetValue(1);
                        company.CurrentStockPrice = (decimal)results.GetValue(2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Company();
            }
            finally
            {
                conn.Close();
            }
            return company;
        }

        public List<Order> getOrders()
        {
            {
                List<Order> orderList = new List<Order>();
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT* FROM Stock";
                    cmd.Parameters.AddWithValue("unexecuted", "unexecuted");
                    cmd.CommandTimeout = 0;
                    using (SqlDataReader results = cmd.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            Order order = new Order();
                            order.Id = Convert.ToInt32(results["id"]);
                            order.Client_id = Convert.ToInt32(results.GetValue(1));
                            order.State = (string)results.GetValue(2);
                            order.Type = (string)results.GetValue(3);
                            order.Value = Convert.ToInt32(results.GetValue(4));
                            order.Quantity = Convert.ToInt32(results.GetValue(5));
                            order.Creation_date = (DateTime)results.GetValue(6);
                            order.Company_id = Convert.ToInt32(results.GetValue(8));
                            orderList.Add(order);

                            Console.WriteLine(order.ToString());
                        }
                        results.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return orderList;
                }
                finally
                {
                    conn.Close();
                }
                return orderList;
            }
        }
    }
}
