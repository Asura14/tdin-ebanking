using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
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
                conn.Open();
                string sqlcmd = "INSERT INTO Stock Values(" + client_id + ", 'unexecuted', 'buy', " + (amount * stockPrice) + ", " + amount + ", '" + (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', null)";
                Console.WriteLine(sqlcmd);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
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
                conn.Open();
                string sqlcmd = "INSERT INTO Stock Values(" + client_id + ", 'unexecuted', 'sell', " + (amount * stockPrice) + ", " + amount + ", " + (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") + "', null)";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
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
                            //order.Creation_date = (DateTime)results.GetValue(6);
                            //order.Execution_date = (DateTime)results.GetValue(7);
                            orderList.Add(order);

                            Console.WriteLine(results["id"] + " " + results["type"]);
                            results.NextResult();
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
                            order.Id = (int)results.GetValue(0);
                            order.Client_id = (int)results.GetValue(1);
                            order.State = (string)results.GetValue(2);
                            order.Type = (string)results.GetValue(3);
                            order.Value = (int)results.GetValue(4);
                            order.Quantity = (int)results.GetValue(5);
                            order.Creation_date = (DateTime)results.GetValue(6);
                            order.Execution_date = (DateTime)results.GetValue(7);
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

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void updateStock(int order_id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "UPDATE Stock SET state = 'executed', execution_date = " + (new DateTime()).ToString();
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
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

        [OperationBehavior(TransactionScopeRequired = true)]
        public void test()
        {
            Console.WriteLine("boas tardes");
        }
    }
}
