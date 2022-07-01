using LiteDB;
using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using System.Diagnostics;

namespace NameCollectionTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            using (var db = new LiteDatabase(@"Filename=C:\Source\NameCollectionTool\NameCollectionTool\Database\NameTest.db;Password=test"))
            {
                var col = db.GetCollection<PersonNameDto>("PersonNames");
                // Get data from DB
                model.PersonNames = col.Query().ToList();
            };

            return View(model);
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
    }
}