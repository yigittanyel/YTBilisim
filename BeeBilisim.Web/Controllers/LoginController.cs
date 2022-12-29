using BeeBilisim.Web.Models;
using DNTCaptcha.Core;
using Hash;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BeeBilisim.Web.Controllers
{
    public class LoginController : Controller
	{
		private readonly BeeDbContext _dbContext;
        private readonly IDNTCaptchaValidatorService validatorService;

        public LoginController(BeeDbContext dbContext,IDNTCaptchaValidatorService validatorService)
		{
			_dbContext = dbContext;
            this.validatorService = validatorService;
        }
		[HttpGet]
        [AllowAnonymous]
        public IActionResult GirisYap()
		{
			return View();
		}
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GirisYap(Kullanicilars a)
        {
            //Captcha Kontrolü 
            if (ModelState.IsValid)
            {
                if (!validatorService.HasRequestValidCaptchaEntry(Language.Turkish, DisplayMode.ShowDigits))
                {
                    TempData["captchaError"] = "Lütfen geçerli bir kod giriniz!";
                    return View(a);
                }

                a.Sifre = Sifreleme.sha1(a.Sifre.Trim());
                var deger = _dbContext.Kullanicilars.FirstOrDefault(x => x.Email==a.Email);
               // var deger = _dbContext.Kullanicilars.FirstOrDefault(x => x.Email == a.Email && x.Sifre == a.Sifre);
                if(deger is null)
                {
                    TempData["loginError"] = "Hatalı kullanıcı adı ya da şifre!";
                    return View(a);
                }
                if (deger != null)
                {
                    if (deger.Sifre != a.Sifre)
                    {
                        TempData["loginError"] = "Hatalı kullanıcı adı ya da şifre!";
                        return View(a);
                    }
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,a.Email)
                };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("GenelDuzenleme", "AdminPanel");
                }
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap","Login");
        }
    }
}
