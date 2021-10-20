﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mzt.WCFEmailSender.MailService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MailData", Namespace="http://schemas.datacontract.org/2004/07/Mouzenidis.Mailer.Model")]
    [System.SerializableAttribute()]
    public partial class MailData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, byte[]> AttachmentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BccField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Mzt.WCFEmailSender.MailService.MailContentType ContentTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, Mzt.WCFEmailSender.MailService.ModelField> ModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Type ModelTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ToField;
        
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
        public System.Collections.Generic.Dictionary<string, byte[]> Attachments {
            get {
                return this.AttachmentsField;
            }
            set {
                if ((object.ReferenceEquals(this.AttachmentsField, value) != true)) {
                    this.AttachmentsField = value;
                    this.RaisePropertyChanged("Attachments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Bcc {
            get {
                return this.BccField;
            }
            set {
                if ((object.ReferenceEquals(this.BccField, value) != true)) {
                    this.BccField = value;
                    this.RaisePropertyChanged("Bcc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mzt.WCFEmailSender.MailService.MailContentType ContentType {
            get {
                return this.ContentTypeField;
            }
            set {
                if ((this.ContentTypeField.Equals(value) != true)) {
                    this.ContentTypeField = value;
                    this.RaisePropertyChanged("ContentType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string From {
            get {
                return this.FromField;
            }
            set {
                if ((object.ReferenceEquals(this.FromField, value) != true)) {
                    this.FromField = value;
                    this.RaisePropertyChanged("From");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, Mzt.WCFEmailSender.MailService.ModelField> Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ModelObject {
            get {
                return this.ModelObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelObjectField, value) != true)) {
                    this.ModelObjectField = value;
                    this.RaisePropertyChanged("ModelObject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Type ModelType {
            get {
                return this.ModelTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelTypeField, value) != true)) {
                    this.ModelTypeField = value;
                    this.RaisePropertyChanged("ModelType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string To {
            get {
                return this.ToField;
            }
            set {
                if ((object.ReferenceEquals(this.ToField, value) != true)) {
                    this.ToField = value;
                    this.RaisePropertyChanged("To");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MailContentType", Namespace="http://schemas.datacontract.org/2004/07/Mouzenidis.Mailer.Model")]
    public enum MailContentType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Html = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ViewName = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ViewTemplate = 20,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModelField", Namespace="http://schemas.datacontract.org/2004/07/Mouzenidis.Mailer.Model")]
    [System.SerializableAttribute()]
    public partial class ModelField : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ValuesField;
        
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
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Values {
            get {
                return this.ValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.ValuesField, value) != true)) {
                    this.ValuesField = value;
                    this.RaisePropertyChanged("Values");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SendResult", Namespace="http://schemas.datacontract.org/2004/07/Mouzenidis.Mailer.Model")]
    [System.SerializableAttribute()]
    public partial class SendResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RequestIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Mzt.WCFEmailSender.MailService.DeliveryStatus StatusField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RequestId {
            get {
                return this.RequestIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RequestIdField, value) != true)) {
                    this.RequestIdField = value;
                    this.RaisePropertyChanged("RequestId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mzt.WCFEmailSender.MailService.DeliveryStatus Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeliveryStatus", Namespace="http://schemas.datacontract.org/2004/07/Mouzenidis.Mailer.Model")]
    public enum DeliveryStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unknown = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Delivered = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Waiting = 20,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 255,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MailService.IMailService")]
    public interface IMailService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/Send", ReplyAction="http://tempuri.org/IMailService/SendResponse")]
        Mzt.WCFEmailSender.MailService.SendResult Send(Mzt.WCFEmailSender.MailService.MailData request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/Send", ReplyAction="http://tempuri.org/IMailService/SendResponse")]
        System.Threading.Tasks.Task<Mzt.WCFEmailSender.MailService.SendResult> SendAsync(Mzt.WCFEmailSender.MailService.MailData request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/Check", ReplyAction="http://tempuri.org/IMailService/CheckResponse")]
        Mzt.WCFEmailSender.MailService.SendResult Check(string requestId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/Check", ReplyAction="http://tempuri.org/IMailService/CheckResponse")]
        System.Threading.Tasks.Task<Mzt.WCFEmailSender.MailService.SendResult> CheckAsync(string requestId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMailServiceChannel : Mzt.WCFEmailSender.MailService.IMailService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MailServiceClient : System.ServiceModel.ClientBase<Mzt.WCFEmailSender.MailService.IMailService>, Mzt.WCFEmailSender.MailService.IMailService {
        
        public MailServiceClient() {
        }
        
        public MailServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MailServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Mzt.WCFEmailSender.MailService.SendResult Send(Mzt.WCFEmailSender.MailService.MailData request) {
            return base.Channel.Send(request);
        }
        
        public System.Threading.Tasks.Task<Mzt.WCFEmailSender.MailService.SendResult> SendAsync(Mzt.WCFEmailSender.MailService.MailData request) {
            return base.Channel.SendAsync(request);
        }
        
        public Mzt.WCFEmailSender.MailService.SendResult Check(string requestId) {
            return base.Channel.Check(requestId);
        }
        
        public System.Threading.Tasks.Task<Mzt.WCFEmailSender.MailService.SendResult> CheckAsync(string requestId) {
            return base.Channel.CheckAsync(requestId);
        }
    }
}