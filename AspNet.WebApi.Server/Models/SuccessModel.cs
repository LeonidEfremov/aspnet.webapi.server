using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Models
{
    /// <summary>Success model.</summary>
    [DataContract]
    public class SuccessModel
    {
        /// <summary>Get or Set Success status.</summary>
        [DataMember]
        public bool Success { get; set; }

        /// <summary> Default state for Success model.</summary>
        public static SuccessModel Default => new SuccessModel { Success = true };
    }

}
