using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNet.WebApi.Server.Extensions
{
    /// <summary>Extensions for <see cref="ActionExecutingContext"/>.</summary>
    public static class ActionContextExtensions
    {
        /// <summary>Is Attribute present for <see cref="ActionExecutingContext"/>.</summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="context">Current <see cref="ActionContext"/>.</param>
        /// <returns>Attribute exists.</returns>
        public static bool HasAttribute<T>(this ActionContext context) =>
            context.ActionDescriptor is ControllerActionDescriptor actionDescriptor
            && (actionDescriptor.MethodInfo.GetCustomAttributes(typeof(T), true).Any() ||
                actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(T), true).Any());
    }
}