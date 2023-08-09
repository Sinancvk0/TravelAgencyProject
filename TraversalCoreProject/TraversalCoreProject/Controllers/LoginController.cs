using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{

    [AllowAnonymous]//Altında bulunduğu tüm kodları geçerli bütün kurallardan muaf tutuyor

    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.SurName,
                Email = p.Mail,
                UserName = p.UserName,



            };
            if (p.Password == p.ConfirmPassword)
            {
                //Şifre alanına deger girilmediği taktirde Null hatasına düşmemesi için kullanıldı.
                if (string.IsNullOrEmpty(p.Password) || string.IsNullOrEmpty(p.ConfirmPassword) || p.Password != p.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifre alanları hatalı veya boş.");
                    return View(p);
                }
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }


        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.userName, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { Area = "Member" });


                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }


    }
}
