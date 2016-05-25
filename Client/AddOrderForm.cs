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

        public AddOrderForm(BankAOpsClient bank)
        {
            this.bank = bank;
            retrieveCompaniesInfo();
            retrieveTypesInfo();
            InitializeComponent();
            companyBox.DataSource = companyList;
            companyBox.DisplayMember = "Name";
            typeBox.DataSource = types;
        }

        public void retrieveCompaniesInfo()
        {
            this.companyList = bank.getCompanies().ToList();
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
                bank.sellStock(1, Convert.ToDouble(textBox2.Text), selectedCompany.Id);
                this.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Something Wrong Happened", "Error");
            }
        }
    }
}
