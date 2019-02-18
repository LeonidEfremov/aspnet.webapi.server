using System;

namespace AspNet.WebApi.Server.Attributes
{
    /// <summary>Required to be parameter not null.</summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class RequiredAttribute : Attribute
    {
    }
}