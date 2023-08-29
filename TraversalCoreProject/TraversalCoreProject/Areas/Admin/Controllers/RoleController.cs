using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateRoleModel model)
        {
            AppRole role = new AppRole()
            {
                Name = model.RoleName

            };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }


        }


        [Route("DeleteRole/{id}")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            await _roleManager.DeleteAsync(values);

            return RedirectToAction("Index");


        }

        [HttpGet]
        [Route("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            UpdateRoleModel updateRoleModel = new UpdateRoleModel()
            {
                RoleID = values.Id,
                RoleName = values.Name

            };

            return View(updateRoleModel);

        }

        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel model)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);

            values.Name = model.RoleName;

            await _roleManager.UpdateAsync(values);

            return RedirectToAction("Index");
        }
    }
}
