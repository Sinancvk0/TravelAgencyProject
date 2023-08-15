using BussinessLayer.Abstract;
using BussinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide g)
        {
             GuideValidator validationRules = new GuideValidator(); 
               ValidationResult result = validationRules.Validate(g);
            if (result.IsValid)
            {
                _guideService.TAdd(g);

                return RedirectToAction("Index", "Destination");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
   
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide g)
        {
          _guideService.TUpdate(g);
          return RedirectToAction("Index");

        }
    }
}
