using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PROJECT.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationRoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> Create(IdentityRole model)
        {
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult()) { 
            
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");
        }
    }
}
