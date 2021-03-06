﻿using System;
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
            List<Company> c = new  List<Company>();
            try {
                return bankAProxy.getCompanies().ToList();
            }
            catch (Exception exc)
            {
                return c;
            }
        }


        public Company GetCompany(int id)
        {
            Company c = new Company();
            try
            {
                return bankAProxy.getCompany(id);
            }
            catch(Exception exc)
            {
                return c;
            }

        }
        public List<Order> GetUnexecutedOrders()
        {
            try {
                return bankAProxy.getUnexecutedOrders().ToList();
            }
            catch(Exception exc)
            {
                return new List<Order>();
            }
        }

        public List<Order> GetClientHistory(int id)
        {
            try {
                return bankAProxy.getClientHistory(id).ToList();
            }
            catch (Exception exc)
            {
                return new List<Order>();
            }
        }

        public Cliente GetClientId(Cliente cliente)
        {
            Cliente c = new Cliente();
            c.Id = 0;
            try
            {
                return bankAProxy.getClientByEmail(cliente);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return c;
            }

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
                bankAProxy.editStock(order);
                return "success";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

    }
}