using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Example.Models
{
    /// <summary>Example model.</summary>
    [DataContract]
    public class ExampleModel
    {
        /// <summary>Gets or sets id.</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Gets or sets Title.</summary>
        [DataMember(IsRequired =true)]
        public string Title { get; set; }

        /// <summary>Gets or sets status.</summary>
        [DataMember]
        public Status Status { get; set; }
    }
}
