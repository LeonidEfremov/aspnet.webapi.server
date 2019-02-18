using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Tests.Models
{
    [DataContract]
    public class SimpleModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool Flag { get; set; }
    }
}