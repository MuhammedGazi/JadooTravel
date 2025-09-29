using JadooTravel.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        private LanguageService _localization;
        private readonly GeminiService _gemini;

        public DefaultController(LanguageService localization, GeminiService gemini)
        {
            _localization = localization;
            _gemini = gemini;
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> GetItinerary([FromBody] string city)
        {
            var output = await _gemini.GenerateItineraryAsync(city, 5);
            return Content(output, "application/json");
        }
    }
}
