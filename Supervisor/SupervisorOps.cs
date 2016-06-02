using System;
using System.ServiceModel;
using System.Messaging;
using System.IO;
using System.Collections.Generic;

namespace Supervisor {
    public class SupervisorOps : ISupervisorOps
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void ReportToSupervisor(string message)
        {
            Console.WriteLine(message);
        }
    }
}
