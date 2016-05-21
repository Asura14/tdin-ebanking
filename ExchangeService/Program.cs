using System;
using System.ServiceModel;
using ExchangeService.InterBank;
using ExchangeService.BankA;
using System.Windows.Forms;

namespace ExchangeService
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f = new ExchangeServiceApp();
            f.ShowDialog();
        }
    }
}
