﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.BankA {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/ServerA")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Client_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Creation_dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Execution_dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Client_id {
            get {
                return this.Client_idField;
            }
            set {
                if ((this.Client_idField.Equals(value) != true)) {
                    this.Client_idField = value;
                    this.RaisePropertyChanged("Client_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Creation_date {
            get {
                return this.Creation_dateField;
            }
            set {
                if ((this.Creation_dateField.Equals(value) != true)) {
                    this.Creation_dateField = value;
                    this.RaisePropertyChanged("Creation_date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Execution_date {
            get {
                return this.Execution_dateField;
            }
            set {
                if ((this.Execution_dateField.Equals(value) != true)) {
                    this.Execution_dateField = value;
                    this.RaisePropertyChanged("Execution_date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Company", Namespace="http://schemas.datacontract.org/2004/07/ServerA")]
    [System.SerializableAttribute()]
    public partial class Company : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal CurrentStockPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal CurrentStockPrice {
            get {
                return this.CurrentStockPriceField;
            }
            set {
                if ((this.CurrentStockPriceField.Equals(value) != true)) {
                    this.CurrentStockPriceField = value;
                    this.RaisePropertyChanged("CurrentStockPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankA.IBankAOps", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IBankAOps {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/buyStock", ReplyAction="http://tempuri.org/IBankAOps/buyStockResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void buyStock(int client_id, double amount, int company_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/sellStock", ReplyAction="http://tempuri.org/IBankAOps/sellStockResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void sellStock(int client_id, double amount, int company_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/checkOrder", ReplyAction="http://tempuri.org/IBankAOps/checkOrderResponse")]
        string checkOrder(int order_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/getUnexecutedOrders", ReplyAction="http://tempuri.org/IBankAOps/getUnexecutedOrdersResponse")]
        Client.BankA.Order[] getUnexecutedOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/getClientHistory", ReplyAction="http://tempuri.org/IBankAOps/getClientHistoryResponse")]
        Client.BankA.Order[] getClientHistory(int client_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/getCompanies", ReplyAction="http://tempuri.org/IBankAOps/getCompaniesResponse")]
        Client.BankA.Company[] getCompanies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/updateStock", ReplyAction="http://tempuri.org/IBankAOps/updateStockResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void updateStock(int order_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAOps/deleteOrder", ReplyAction="http://tempuri.org/IBankAOps/deleteOrderResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        void deleteOrder(int order_id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankAOpsChannel : Client.BankA.IBankAOps, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankAOpsClient : System.ServiceModel.ClientBase<Client.BankA.IBankAOps>, Client.BankA.IBankAOps {
        
        public BankAOpsClient() {
        }
        
        public BankAOpsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankAOpsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAOpsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAOpsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void buyStock(int client_id, double amount, int company_id) {
            base.Channel.buyStock(client_id, amount, company_id);
        }
        
        public void sellStock(int client_id, double amount, int company_id) {
            base.Channel.sellStock(client_id, amount, company_id);
        }
        
        public string checkOrder(int order_id) {
            return base.Channel.checkOrder(order_id);
        }
        
        public Client.BankA.Order[] getUnexecutedOrders() {
            return base.Channel.getUnexecutedOrders();
        }
        
        public Client.BankA.Order[] getClientHistory(int client_id) {
            return base.Channel.getClientHistory(client_id);
        }
        
        public Client.BankA.Company[] getCompanies() {
            return base.Channel.getCompanies();
        }
        
        public void updateStock(int order_id) {
            base.Channel.updateStock(order_id);
        }
        
        public void deleteOrder(int order_id) {
            base.Channel.deleteOrder(order_id);
        }
    }
}
