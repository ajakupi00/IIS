﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExerciseReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExerciseReference.ExerciseServiceSoap")]
    public interface ExerciseServiceSoap
    {
        
        // CODEGEN: Generating message contract since element name exerciseName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchExerciseByName", ReplyAction="*")]
        ExerciseReference.SearchExerciseByNameResponse SearchExerciseByName(ExerciseReference.SearchExerciseByNameRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchExerciseByName", ReplyAction="*")]
        System.Threading.Tasks.Task<ExerciseReference.SearchExerciseByNameResponse> SearchExerciseByNameAsync(ExerciseReference.SearchExerciseByNameRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchExerciseByNameRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchExerciseByName", Namespace="http://tempuri.org/", Order=0)]
        public ExerciseReference.SearchExerciseByNameRequestBody Body;
        
        public SearchExerciseByNameRequest()
        {
        }
        
        public SearchExerciseByNameRequest(ExerciseReference.SearchExerciseByNameRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchExerciseByNameRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string exerciseName;
        
        public SearchExerciseByNameRequestBody()
        {
        }
        
        public SearchExerciseByNameRequestBody(string exerciseName)
        {
            this.exerciseName = exerciseName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchExerciseByNameResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchExerciseByNameResponse", Namespace="http://tempuri.org/", Order=0)]
        public ExerciseReference.SearchExerciseByNameResponseBody Body;
        
        public SearchExerciseByNameResponse()
        {
        }
        
        public SearchExerciseByNameResponse(ExerciseReference.SearchExerciseByNameResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchExerciseByNameResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SearchExerciseByNameResult;
        
        public SearchExerciseByNameResponseBody()
        {
        }
        
        public SearchExerciseByNameResponseBody(string SearchExerciseByNameResult)
        {
            this.SearchExerciseByNameResult = SearchExerciseByNameResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ExerciseServiceSoapChannel : ExerciseReference.ExerciseServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ExerciseServiceSoapClient : System.ServiceModel.ClientBase<ExerciseReference.ExerciseServiceSoap>, ExerciseReference.ExerciseServiceSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ExerciseServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(ExerciseServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), ExerciseServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ExerciseServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ExerciseServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ExerciseServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ExerciseServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ExerciseServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ExerciseReference.SearchExerciseByNameResponse ExerciseReference.ExerciseServiceSoap.SearchExerciseByName(ExerciseReference.SearchExerciseByNameRequest request)
        {
            return base.Channel.SearchExerciseByName(request);
        }
        
        public string SearchExerciseByName(string exerciseName)
        {
            ExerciseReference.SearchExerciseByNameRequest inValue = new ExerciseReference.SearchExerciseByNameRequest();
            inValue.Body = new ExerciseReference.SearchExerciseByNameRequestBody();
            inValue.Body.exerciseName = exerciseName;
            ExerciseReference.SearchExerciseByNameResponse retVal = ((ExerciseReference.ExerciseServiceSoap)(this)).SearchExerciseByName(inValue);
            return retVal.Body.SearchExerciseByNameResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ExerciseReference.SearchExerciseByNameResponse> ExerciseReference.ExerciseServiceSoap.SearchExerciseByNameAsync(ExerciseReference.SearchExerciseByNameRequest request)
        {
            return base.Channel.SearchExerciseByNameAsync(request);
        }
        
        public System.Threading.Tasks.Task<ExerciseReference.SearchExerciseByNameResponse> SearchExerciseByNameAsync(string exerciseName)
        {
            ExerciseReference.SearchExerciseByNameRequest inValue = new ExerciseReference.SearchExerciseByNameRequest();
            inValue.Body = new ExerciseReference.SearchExerciseByNameRequestBody();
            inValue.Body.exerciseName = exerciseName;
            return ((ExerciseReference.ExerciseServiceSoap)(this)).SearchExerciseByNameAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ExerciseServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.ExerciseServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ExerciseServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:59598/ExerciseService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.ExerciseServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:59598/ExerciseService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            ExerciseServiceSoap,
            
            ExerciseServiceSoap12,
        }
    }
}
