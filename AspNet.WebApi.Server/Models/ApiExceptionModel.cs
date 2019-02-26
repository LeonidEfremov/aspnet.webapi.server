using AspNet.WebApi.Common.Exceptions;
using AspNet.WebApi.Common.Exceptions.Interfaces;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AspNet.WebApi.Server.Models
{
    /// <inheritdoc />
    [DataContract]
    public class ApiExceptionModel : IApiException
    {
        /// <inheritdoc />
        public ApiExceptionModel(ApiException ex)
        {
            Message = ex.Message;
            StatusCode = ex.StatusCode;
            ReasonCode = ex.ReasonCode;
        }

        /// <inheritdoc />
        [JsonConstructor]
        public ApiExceptionModel(string message, int statusCode, string reasonCode)
        {
            Message = message;
            StatusCode = statusCode;
            ReasonCode = reasonCode;
        }

        /// <inheritdoc />
        [DataMember]
        public string Message { get; }

        /// <inheritdoc />
        [DataMember]
        public int StatusCode { get; }

        /// <inheritdoc />
        [DataMember]
        public string ReasonCode { get; }
    }
}