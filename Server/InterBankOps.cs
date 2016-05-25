using System;
using System.ServiceModel;
using Server.BankA;
using Server.Supervisor;
using System.Collections.Generic;

namespace InterBank
{
    public class InterBankOps : IInterBankOps
    {
        BankAOpsClient bankAProxy = new BankAOpsClient();
        SupervisorOpsClient supervisor = new SupervisorOpsClient();

        [OperationBehavior(TransactionScopeRequired = true)]
        public void TransferAtoB(int acctA, int acctB, double amount)
        {
            string message = String.Format("Transfer of {0:F2} from A{1} to B{2}", amount, acctA, acctB);
            supervisor.ReportToSupervisor(message);        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void TransferBtoA(int acctB, int acctA, double amount)
        {
            string message = String.Format("Transfer of {0:F2} from B{1} to A{2}", amount, acctB, acctA);
            supervisor.ReportToSupervisor(message);
            bankAProxy.buyStock(1, 5, 1);
            bankAProxy.buyStock(1, 10, 1);
        }
    }
}
