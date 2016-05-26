using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Server {
  class Program {
    static void Main(string[] args) {
            /*WebServiceHost host = new WebServiceHost(typeof(InterBank.InterBankOps), new Uri("http://localhost:8000/");
            host.Open();
            Console.WriteLine("Service InterBank Active. Press <Enter> to close.");
            Console.ReadLine();
            host.Close();*/
            WebServiceHost host = new WebServiceHost(typeof(InterBank.InterBankOps), new Uri("http://localhost:8000/"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(InterBank.IInterBankOps), new WebHttpBinding(), "");
                host.Open();/*
                using (ChannelFactory<InterBank.IInterBankOps> cf = new ChannelFactory<InterBank.IInterBankOps>(new WebHttpBinding(), "http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    InterBank.IInterBankOps channel = cf.CreateChannel();

                    string s;

                    Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                    //s = channel.EchoWithGet("Hello, world");
                   // Console.WriteLine("   Output: {0}", s);

                    Console.WriteLine("");
                    Console.WriteLine("This can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("");

                    Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                    //s = channel.EchoWithPost("Hello, world");
                    //Console.WriteLine("   Output: {0}", s);
                    Console.WriteLine("");
                }
                */
                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
            finally
            {
                host.Close();
            }
        }
  }
}
