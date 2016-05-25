using System;
using System.ServiceModel;
using Server.BankA;
using Server.Supervisor;
using System.Collections.Generic;
using System.Linq;

namespace InterBank
{
    public class InterBankOps : IInterBankOps
    {
        BankAOpsClient bankAProxy;
        public InterBankOps()
        {
            bankAProxy = new BankAOpsClient();
        }

        public List<Company> GetCompanies()
        {
            return bankAProxy.getCompanies().ToList();
        }

        public List<Order> GetUnexecutedOrders()
        {
            return bankAProxy.getUnexecutedOrders().ToList();
        }

        public List<Order> GetClientHistory(int id)
        {
            return bankAProxy.getClientHistory(id).ToList();
        }


      /*  public string PostOrder(string clientID, companyID, amount, type )
        {
            try
            {
                if (h.ToLower().Equals("buy")){
                    bankAProxy.buyStock(Int32.Parse(x), Convert.ToDouble(z), Int32.Parse(y));
                    return "success";
                }
                else if(h.ToLower().Equals("sell")) {
                    bankAProxy.buyStock(Int32.Parse(x), Convert.ToDouble(z), Int32.Parse(y));
                    return "success";
                }
            }
            catch(Exception exc)
            {
                return exc.Message;
            }
            return "error";
        }
        */
    }
}
