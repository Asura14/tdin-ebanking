using ExchangeService.BankA;
using ExchangeService.InterBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Net.Mail;
using System.Net;

namespace ExchangeService
{
    public partial class ExchangeServiceApp : Form
    {
        List<Order> ordersToExecute;
        List<Order> todaysExecutedOrders;
        BankAOpsClient bankAProxy;
        InterBankOpsClient proxy;
        string pass = "tdin2016";

        public ExchangeServiceApp()
        {
            ordersToExecute = new List<Order>();
            todaysExecutedOrders = new List<Order>();
            proxy = new InterBankOpsClient();
            bankAProxy = new BankAOpsClient();
            bankAProxy.Open();
            ordersToExecute = bankAProxy.getUnexecutedOrders().ToList();
            
            InitializeComponent();

            updateUnexecutedOrders();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                string selecionado = dataGridUnexecuted.SelectedCells[0].Value.ToString();
                int id = Int32.Parse(selecionado);

                Order tempOrder = new Order();
                tempOrder.Id = id;
                tempOrder.Client_id = Int32.Parse(dataGridUnexecuted.SelectedCells[1].Value.ToString());
                DateTime dt;
                DateTime.TryParse(dataGridUnexecuted.SelectedCells[2].Value.ToString(), out dt);
                tempOrder.Creation_date = dt;
                tempOrder.Quantity = Int32.Parse(dataGridUnexecuted.SelectedCells[3].Value.ToString());
                tempOrder.State = dataGridUnexecuted.SelectedCells[4].Value.ToString();
                tempOrder.Type = dataGridUnexecuted.SelectedCells[5].Value.ToString();
                tempOrder.Value = Int32.Parse(dataGridUnexecuted.SelectedCells[6].Value.ToString());
                tempOrder.Execution_date = DateTime.Now;
                todaysExecutedOrders.Add(tempOrder);

                bankAProxy.updateStock(id);
                updateUnexecutedOrders();
                updateExecutedOrders();
                Cliente client = bankAProxy.getClient(tempOrder.Client_id);
                sendEmail(client, tempOrder.Quantity, tempOrder.Value, tempOrder.Type);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
                MessageBox.Show("Nenhum Item selecionado", "Alerta");
            }
        }

        public void updateUnexecutedOrders()
        {
            try
            {
                ordersToExecute = bankAProxy.getUnexecutedOrders().ToList();
                dataGridUnexecuted.Rows.Clear();
                foreach (Order order in ordersToExecute)
                {
                    Console.Write(order.Id);
                    string[] temp = { order.Id.ToString(), order.Client_id.ToString(), order.Creation_date.ToString(), order.Quantity.ToString(), order.State.ToString(), order.Type, order.Value.ToString()};
                    dataGridUnexecuted.Rows.Add(temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void updateExecutedOrders()
        {
            try
            {
                dataGridExecuted.Rows.Clear();
                foreach (Order order in todaysExecutedOrders)
                {
                    Console.Write(order.Id);
                    string[] temp = { order.Id.ToString(), order.Client_id.ToString(), order.Creation_date.ToString(), order.Quantity.ToString(), order.State.ToString(), order.Type, order.Value.ToString(), order.Execution_date.ToString() };
                    dataGridExecuted.Rows.Add(temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void sendEmail(Cliente client, int quantity, double value, string type)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.live.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("luismiguel667@hotmail.com", pass)
                };
                using (var message = new MailMessage("luismiguel667@hotmail.com", client.Email)
                {
                    Subject = "Your Order has been executed",
                    Body = "Dear "+ client.Name + ", \n Congratulations! Your order has been executed. Your " + type + " of " + quantity + " actions, for a total of " + value + "€. \n"
                })
                {
                    smtp.Send(message);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            updateUnexecutedOrders();
        }
    }
}
