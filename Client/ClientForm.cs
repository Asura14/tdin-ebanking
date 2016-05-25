using Client.BankA;
using Client.InterBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        InterBankOpsClient proxy;
        BankAOpsClient bankAProxy;
        public ClientForm()
        {
            proxy = new InterBankOpsClient();
            bankAProxy = new BankAOpsClient();

            InitializeComponent();
            atualizaLista(bankAProxy.getUnexecutedOrders().ToList());
        }

        private void atualizaLista(List<Order> orders)
        {
            try
            {
                ordersList.Rows.Clear();
                foreach (Order ped in orders)
                {
                    string[] temp = { ped.Id.ToString(), ped.Client_id.ToString(), ped.Creation_date.ToString(), ped.Quantity.ToString(), ped.State, ped.Type, ped.Value.ToString() };
                    ordersList.Rows.Add(temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form f = new AddOrderForm(bankAProxy);
            f.Show();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            try {
                string selecionado = ordersList.SelectedCells[0].Value.ToString();
                int id = Int32.Parse(selecionado);
                bankAProxy.deleteOrder(id);
                atualizaLista(bankAProxy.getUnexecutedOrders().ToList());
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
                MessageBox.Show("No order selected", "Error");
            }
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            bankAProxy.Close();
            if (proxy.State == CommunicationState.Opened)
                proxy.Close();
        }
    }
}
