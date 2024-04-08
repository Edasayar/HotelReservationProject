using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int Id)
        {
            var user= _userManager.Users.FirstOrDefault(x => x.Id == Id);
            TempData["userId"] = user.Id;
            var roles= _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignVM> roleAssignVMs = new List<RoleAssignVM>();
            foreach(var item in roles)
            {
                RoleAssignVM model = new RoleAssignVM();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignVMs.Add(model);
            }
            return View(roleAssignVMs);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignVM> roleAssignVM)
        {
            var userId = (int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(r => r.Id == userId);
            foreach(var item in roleAssignVM)
            {
                if (!string.IsNullOrEmpty(item.RoleName))
                {
                    if (item.RoleExist)
                    {
                        await _userManager.AddToRoleAsync(user, item.RoleName);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
