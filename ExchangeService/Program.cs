using System;
using System.ServiceModel;
using ExchangeService.InterBank;
using ExchangeService.BankA;

namespace ExchangeService {
  class Program {
    static void Main(string[] args) {
      int acctA = 121, acctB = 1004;
      double amount = 80.00;
      
      InterBankOpsClient proxy = new InterBankOpsClient();
      BankAOpsClient bankAProxy = new BankAOpsClient();
      Console.WriteLine("Doing a transfer (B to A) of {0:F2}", amount);
      try {
        proxy.TransferBtoA(acctB, acctA, amount);
      }
      catch (Exception ex) {
        Console.WriteLine("Transaction Aborted: " + ex.Message);
      }
      bankAProxy.Close();
      if (proxy.State == CommunicationState.Opened)
        proxy.Close();
      Console.WriteLine("Press <Enter> to terminate.");
      Console.ReadLine();
    }
  }
}
