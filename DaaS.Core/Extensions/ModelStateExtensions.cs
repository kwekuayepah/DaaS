using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DaaS.Core.Extensions
{
    public static class ModelStateExtensions
    {
        /// <summary>
        /// Gets all error messages in the model state as string
        /// </summary>
        /// <param name="modelState">Must be valid and not null</param>
        /// <param name="separator">Will be used to separate the error messages. Defaults to line feed if empty.</param>
        /// <returns></returns>
        public static string GetErrorMessageAsString(this ModelStateDictionary modelState, string separator)
        {
            if (modelState == null)
            {
                return string.Empty;
            }
            if (modelState.IsValid)
            {
                return string.Empty;
            }
            var errorMessage = string.Empty;
            if (modelState.ErrorCount > 0)
            {
                foreach (var modelStateValue in modelState.Values)
                {
                    errorMessage = string.Join(separator ?? "\r\n", modelStateValue.Errors.Select(e => e.ErrorMessage));
                }
            }

            return errorMessage;
        }
    }
}