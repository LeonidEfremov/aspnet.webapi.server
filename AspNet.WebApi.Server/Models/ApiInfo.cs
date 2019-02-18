using System;

namespace AspNet.WebApi.Server.Models
{
    /// <summary>Service information.</summary>
    public class ApiInfo
    {
        /// <summary>Gets or sets Assembly name.</summary>
        public string AssemblyName { get; set; }

        /// <summary>Gets or sets Assembly description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets Assembly version.</summary>
        public Version Version { get; set; }

        /// <summary>Gets or sets Windows service name.</summary>
        public string ServiceName { get; set; }

        /// <summary>Gets or sets API version.</summary>
        public string ApiVersion { get; set; }

        /// <summary>Gets or sets Windows service display name.</summary>
        public string DisplayName { get; set; }
    }
}