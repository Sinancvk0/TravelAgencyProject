using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());


        public IActionResult Index()
        {
            var values = destinationManager.TGetList();

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
            destinationManager.TAdd(p);

            return RedirectToAction("Index");


        }
        public IActionResult DeleteDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditDestination(Destination p)
        {
           destinationManager.TUpdate(p);
            return RedirectToAction("Index");
        }


    }
}
