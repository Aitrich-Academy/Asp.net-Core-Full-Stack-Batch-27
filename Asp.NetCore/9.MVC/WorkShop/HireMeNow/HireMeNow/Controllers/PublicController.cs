using HireMeNow.Interface;
using HireMeNow.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow.Controllers
{
    public class PublicController : Controller
    {
        private readonly IPublicService publicService;

        public PublicController(IPublicService publicService)
        {
            this.publicService = publicService;
        }

        [HttpGet]
        public IActionResult JobProviderRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult JobProviderRegistration(User user)
        {
            try
            {
                 publicService.Register(user);

                return RedirectToAction("Login");

            }
            catch
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email,string password)
        {
            try
            {
                var user = publicService.LoginJobProvider(email, password);

                if(user != null)
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("CompanyId", user.CompanyId.ToString());

                    return RedirectToAction("PostJob", "JobProvider");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
