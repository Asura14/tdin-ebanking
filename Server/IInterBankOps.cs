using Server.BankA;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace InterBank
{
    [ServiceContract]
    public interface IInterBankOps
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Company> GetCompanies();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Order> GetClientHistory(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        System.Collections.Generic.List<Order> GetUnexecutedOrders();


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/PostOrder")]
        string PostOrder(Order order, Company comp);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/DeleteOrder")]
        string DeleteOrder(Order order);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/UpdateOrder")]
        string UpdateOrder(Order order);
    }
}

