using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]//Altında bulunduğu tüm kodları geçerli bütün kurallardan muaf tutuyor

    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

    }
}
