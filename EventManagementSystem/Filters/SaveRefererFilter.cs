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
        }
    }
}
