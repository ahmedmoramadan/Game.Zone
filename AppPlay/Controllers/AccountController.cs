

namespace APPPlay.Controllers
{ 
    //Admin Ahmedd Ahmedd111@000
    public class AccountController : Controller
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly SignInManager<Appuser> _signInManager;

        public AccountController(UserManager<Appuser> userManager, SignInManager<Appuser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult register1()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register1(RegisterViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                Appuser myuser = new Appuser();
                myuser.UserName = uservm.Name;
                myuser.Address = uservm.Address;
                myuser.PasswordHash = uservm.password;
                IdentityResult result = await _userManager.CreateAsync(myuser, uservm.password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(myuser, "user");
                    await _signInManager.SignInAsync(myuser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(uservm);

        }
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                Appuser myuser = new Appuser();
                myuser.UserName = uservm.Name;
                myuser.Address = uservm.Address;
                myuser.PasswordHash = uservm.password;
                IdentityResult result = await _userManager.CreateAsync(myuser, uservm.password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(myuser, "Admin");
                    await _signInManager.SignInAsync(myuser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(uservm);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Appuser? appuser = await _userManager.FindByNameAsync(model.Username);
                if (appuser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appuser, model.password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appuser, model.rememberme);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "error");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
       
    }
}
