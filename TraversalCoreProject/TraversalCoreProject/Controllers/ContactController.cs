using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
       ContactUsManager contactUsManager=new ContactUsManager(new EfContactUsDal());
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
