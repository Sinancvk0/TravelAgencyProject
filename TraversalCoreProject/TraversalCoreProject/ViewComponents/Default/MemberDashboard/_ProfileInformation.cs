using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.Default.MemberDashboard
{
    public class _ProfileInformation:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.phone = values.PhoneNumber;
            ViewBag.email=values.Email;
            ViewBag.Location = "Türkiye";
            return View();


        }
    }
}
