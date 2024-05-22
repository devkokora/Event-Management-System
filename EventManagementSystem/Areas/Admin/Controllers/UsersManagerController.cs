using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersManagerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }        

        public async Task<IActionResult> Detail(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User? user)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Suspend(int id, TimeSpan duration, string reason)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Ban(int id, string reason)
        {
            return View();
        }
    }
}
