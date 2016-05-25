using ServerA;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BankA
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IBankOpsCallback))]
    public interface IBankAOps
    {

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void buyStock(int client_id, double amount, int company_id);
    
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void sellStock(int client_id, double amount, int company_id);

        [OperationContract]
        string checkOrder(int order_id);

        [OperationContract]
        List<Order> getUnexecutedOrders();

        [OperationContract]
        List<Order> getClientHistory(int client_id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void updateStock(int order_id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void test();

    }

    public interface IBankOpsCallback
    {
        [OperationContract(IsOneWay = true)]
        void notifyStockStockBought(int client_id, double amount, int company_id);

        [OperationContract(IsOneWay = true)]
        void notifyStockStockSold(int client_id, double amount, int company_id);

    }

}
