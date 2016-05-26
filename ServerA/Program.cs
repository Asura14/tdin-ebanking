using System;
using System.ServiceModel;

namespace ServerA {
  class Program {
    static void Main(string[] args) {
      ServiceHost host = new ServiceHost(typeof(BankA.BankAOps));
            try {
                host.Open();
                Console.WriteLine("Service BankA Active. Press <Enter> to close.");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
        }
  }
}
