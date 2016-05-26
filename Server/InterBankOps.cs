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


        public string PostOrder(Order order, Company comp)
        {
            try
            {
                if (order.Type.ToLower().Equals("buy"))
                {
                    bankAProxy.buyStock(order.Client_id, order.Quantity, comp.Id);
                    return "success";
                }
                else if (order.Type.ToLower().Equals("sell"))
                {
                    bankAProxy.sellStock(order.Id, order.Quantity, comp.Id);
                    return "success";
                }
                return order.ToString();
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            return "error";
        }

        public string DeleteOrder(Order order)
        {
            try
            {
                bankAProxy.deleteOrder(order.Id);
                return "success";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public String UpdateOrder(Order order)
        {
            try
            {
                bankAProxy.updateStock(order.Id);
                return "success";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

    }
}