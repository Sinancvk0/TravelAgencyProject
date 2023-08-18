using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [Route("Index")]
        public IActionResult Index()
        {var values=_contactUsService.TGetList();
            return View(values);
        }
        [Route("ContactusTrue/{id}")]
        public IActionResult ContactusTrue(int id)
        {
            _contactUsService.TChangeToTrueContactUs(id);

            return RedirectToAction("Index", "ContactUS", new { area = "Admin" });

        }
        [Route("ContactusFalse/{id}")]
        public IActionResult ContactusFalse(int id)
        {
            _contactUsService.TChangeToFalseContactUs(id);

            return RedirectToAction("Index", "ContactUS", new { area = "Admin" });

        }
    }
}
