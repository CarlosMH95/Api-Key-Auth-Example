using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api_Key_Auth_Example.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            //Get the configuration service
            var configuration  = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            //get the api key from the configuration
            var apiKey = configuration.GetValue<string>(key:"ApiKey");
            //Validate the ApiKey of the request
            if (!apiKey.Equals(potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
             await next();
        }
    }
}
