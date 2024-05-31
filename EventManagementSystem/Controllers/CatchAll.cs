using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    public class CatchAll : Controller
    {
        public IActionResult Index()
        {
            // Pass exception details from middleware to a controller action
            var exceptionDetails = HttpContext.Items["ExceptionDetails"] as string;
            if (!string.IsNullOrEmpty(exceptionDetails))
            {
                ViewBag.ExceptionDetails = exceptionDetails;
            }
            return View();
        }
    }
}
