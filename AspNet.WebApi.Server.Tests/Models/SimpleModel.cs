using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Tests.Models
{
    [DataContract]
    public class SimpleModel
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [StringLength(3)]
        [Required]
        public string Title { get; set; }

        [DataMember]
        [Required]
        public bool Flag { get; set; }
    }
}