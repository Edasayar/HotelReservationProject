using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleVM addRoleVM)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleVM.RoleName,
            };
            var result = await _roleManager.CreateAsync(appRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int Id)
        {
            var value = _roleManager.Roles.FirstOrDefault(r => r.Id == Id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int Id)
        {
            var value = _roleManager.Roles.First(r => r.Id == Id);
            UpdateRoleVM updateRoleVM = new UpdateRoleVM()
            {
                Id = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleVM);
        }

        [HttpPost] 
        public async Task<IActionResult> UpdateRole(UpdateRoleVM updateRoleVM)
        {
            var value = _roleManager.Roles.FirstOrDefault(r=>r.Id==updateRoleVM.Id);
            value.Name=updateRoleVM.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
