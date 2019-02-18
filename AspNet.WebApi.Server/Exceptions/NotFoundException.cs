using System;

namespace AspNet.WebApi.Server.Exceptions
{
    /// <summary>Document not Found API exception (HTTP 404).</summary>
    public class NotFoundException : ApiException
    {
        /// <inheritdoc cref="ApiException.STATUS_CODE" />
        public new const int STATUS_CODE = 404;

        /// <inheritdoc cref="ApiException.REASON_CODE" />
        public new const string REASON_CODE = "NOT_FOUND";

        /// <inheritdoc cref="System.Exception" />
        public NotFoundException() : base(STATUS_CODE, REASON_CODE, null) { }

        /// <inheritdoc cref="System.Exception(string)" />
        public NotFoundException(string message) : base(STATUS_CODE, REASON_CODE, message) { }

        /// <inheritdoc cref="System.Exception(string,Exception)" />
        public NotFoundException(string message, Exception innerException) : base(STATUS_CODE, REASON_CODE, message, innerException) { }

        /// <inheritdoc cref="ApiException(int,string,string,System.Exception)" />
        public NotFoundException(int statusCode, string reasonCode, string message = null, Exception innerException = null)
            : base(statusCode, reasonCode, message, innerException) { }
    }
}