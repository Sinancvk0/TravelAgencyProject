using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _userService;

        public UserController(IAppUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetList();

            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values= _userService.TGetByID(id);
            _userService.TDelete(values);
            return RedirectToAction("Index");   

        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values=_userService.TGetByID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser (AppUser appUser)
        {
           _userService.TUpdate(appUser);
            return RedirectToAction("Index");

        }

    }
}
