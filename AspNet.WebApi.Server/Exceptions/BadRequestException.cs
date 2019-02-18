using System;

namespace AspNet.WebApi.Server.Exceptions
{
    /// <summary>BadRequest API exception (HTTP 400).</summary>
    public class BadRequestException : ApiException
    {
        /// <inheritdoc cref="ApiException.STATUS_CODE" />
        public new const int STATUS_CODE = 400;

        /// <inheritdoc cref="ApiException.REASON_CODE" />
        public new const string REASON_CODE = "BAD_REQUEST";

        /// <inheritdoc cref="System.Exception" />
        public BadRequestException() : base(STATUS_CODE, REASON_CODE, null) { }

        /// <inheritdoc cref="System.Exception(string)" />
        public BadRequestException(string message) : base(STATUS_CODE, REASON_CODE, message) { }

        /// <inheritdoc cref="System.Exception(string,Exception)" />
        public BadRequestException(string message, Exception innerException) : base(STATUS_CODE, REASON_CODE, message, innerException) { }

        /// <inheritdoc cref="ApiException(int,string,string,System.Exception)" />
        public BadRequestException(int statusCode, string reasonCode, string message = null, Exception innerException = null)
            : base(statusCode, reasonCode, message, innerException) { }
    }
}