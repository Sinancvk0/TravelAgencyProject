using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
