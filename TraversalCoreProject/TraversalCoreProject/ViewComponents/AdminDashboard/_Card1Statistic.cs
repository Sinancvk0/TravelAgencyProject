using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _Card1Statistic:ViewComponent
    {
        Context c = new();
        public IViewComponentResult Invoke()
        {

            ViewBag.s1 = c.Destinations.Count();
            ViewBag.s2 = c.Users.Count();

            return View();  
        }
    }
}
