using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Prng;
using System.Collections.Generic;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());

            return Json(jsonCity);

        }
        [HttpPost]
        public IActionResult CityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);

            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values=_destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);


        }

        
        public IActionResult Delete(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return Ok();

        }
        public IActionResult Update(Destination destination)
        {
    
            _destinationService.TUpdate(destination);
            var v= JsonConvert.SerializeObject(destination);
            return Json(v);


        }


    }

}

