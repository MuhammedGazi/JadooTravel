using JadooTravel.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        private LanguageService _localization;

        public DefaultController(LanguageService localization)
        {
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome=_localization.Getkey("Welcome").Value;
            var currentCulture=Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                });
            return RedirectToAction(Request.Headers["Referer"].ToString());
            //return RedirectToAction("Index");
        }
    }
}
