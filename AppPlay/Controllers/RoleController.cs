using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APPPlay.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(RoleVM RVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = RVM.Name;
                IdentityResult ruselt = await _roleManager.CreateAsync(identityRole);
                if(ruselt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var i in ruselt.Errors)
                    {
                        ModelState.AddModelError("", i.Description + " da error u brooo");
                    }
                }
            }
            return View();
        }
    }
}
