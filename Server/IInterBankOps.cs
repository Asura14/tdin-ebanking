using Server.BankA;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace InterBank {
    [ServiceContract]
    public interface IInterBankOps {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Company> GetCompanies();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Order> GetClientHistory(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Order> GetUnexecutedOrders();


        /*[OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped ,Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/PostOrder")]
        string PostOrder(string clientID, string companyID, string amount, string type);*/
    }
}
