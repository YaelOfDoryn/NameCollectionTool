using LiteDB;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;
using System.Diagnostics;

namespace NameCollectionTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonNameService _personNameService;
        private readonly IPlaceNamesService _placeNameService;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig, IPersonNameService personNameService, IPlaceNamesService placeNameService)
        {
            _logger = logger;
            _personNameService = personNameService;
            _placeNameService = placeNameService;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.PersonNames = _personNameService.GetAllPersonNames();
            model.PlaceNames = _placeNameService.GetAllNames();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}