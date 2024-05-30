using Microsoft.AspNetCore.Mvc.Filters;

namespace EventManagementSystem.Filters
{
    public class SaveRefererFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                context.HttpContext.Response.Headers.Append("Referer", referer);
            }
        }
    }
}
