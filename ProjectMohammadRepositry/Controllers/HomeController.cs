using Asp.Common.SessionConfig;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ProjectMohammadRepositry.Models;
using System.Diagnostics;

namespace ProjectMohammadRepositry.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionConfigService _sessionService;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(ILogger<HomeController> logger, ISessionConfigService SessionService, IHttpContextAccessor accessor) : base(SessionService)
        {
            _logger = logger;
            _sessionService = SessionService;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<JsonResult> SetAppLanguage(string? culture)
        {
            try
            {
                if (string.IsNullOrEmpty(culture))
                {
                    culture =
                        (_sessionService.CurrentLang.Contains("ar")) ? "en-US" : "ar";
                }
                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(30) });
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}