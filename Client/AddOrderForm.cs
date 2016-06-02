using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.BankA;

namespace Client
{
    public partial class AddOrderForm : Form
    {

        BankAOpsClient bank;
        List<Company> companyList;
        List<String> types;
        List<Cliente> clients;

        public AddOrderForm(BankAOpsClient bank)
        {
            this.bank = bank;
            retrieveCompaniesInfo();
            retrieveTypesInfo();
            InitializeComponent();
            companyBox.DataSource = companyList;
            companyBox.DisplayMember = "Name";
            typeBox.DataSource = types;
            retrieveClientInfo();
            comboBoxClient.DataSource = clients;
            comboBoxClient.DisplayMember = "Name";
        }

        public void retrieveCompaniesInfo()
        {
            this.companyList = bank.getCompanies().ToList();
        }

        public void retrieveClientInfo()
        {
            clients = bank.getClients().ToList();
        }

        public void retrieveTypesInfo()
        {
            List<string> types = new List<string>();
            types.Add("Buy");
            types.Add("Sell");
            this.types = types;

        }

        private void companyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Company selectedCompany = (Company) companyBox.SelectedItem;
                this.priceLabel.Text = selectedCompany.CurrentStockPrice.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
                MessageBox.Show("No order selected", "Error");
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            try {
                Company selectedCompany = (Company)companyBox.SelectedItem;
                string type = (string)typeBox.SelectedItem;
                Cliente client = (Cliente)comboBoxClient.SelectedItem;
                if (type.Equals("Sell")){
                    bank.sellStock(client.Id, Convert.ToDouble(textBox2.Text), selectedCompany.Id);
                }
                else
                {
                    bank.buyStock(client.Id, Convert.ToDouble(textBox2.Text), selectedCompany.Id);
                }
                this.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Something Wrong Happened", "Error");
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente selectedClient = (Cliente)comboBoxClient.SelectedItem;;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
                MessageBox.Show("No order selected", "Error");
            }
        }
    }
}
