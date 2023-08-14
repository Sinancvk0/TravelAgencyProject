using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {

        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();

            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();


        }
        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            _destinationService.TAdd(p);

            return RedirectToAction("Index");


        }
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }


    }
}
