using Microsoft.AspNetCore.Mvc;
using FreshShoop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreshShoop.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var user = new IdentityUser { UserName = model.Name, Email = model.Email };
            var res = await  userManager.CreateAsync(user,model.Password);
            if(res.Succeeded)

            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Admin");
            }
            foreach(var erro in res.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
            return View(model);
        }

    }
}