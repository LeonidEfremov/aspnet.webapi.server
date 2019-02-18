using System;

namespace AspNet.WebApi.Server.Attributes
{
    /// <summary>Allow to skip model validation.</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreModelValidationAttribute : Attribute
    {
    }
}