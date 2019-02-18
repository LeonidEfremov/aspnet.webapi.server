using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Tests.Models
{
    [DataContract]
    public class ContextItemModel
    {
        [DataMember]
        public string Header { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}