using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Example.Models
{
    /// <summary>Status enumeration.</summary>
    [DataContract]
    public enum Status
    {
        /// <summary>Undefined.</summary>
        [EnumMember(Value = "UNDEFINED")]
        Undefined = 0,

        /// <summary>Active.</summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary>Paused.</summary>
        [EnumMember(Value = "PAUSED")]
        Paused
    }
}
