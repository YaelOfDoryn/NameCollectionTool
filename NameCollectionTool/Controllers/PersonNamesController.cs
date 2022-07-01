using Microsoft.AspNetCore.Mvc;

namespace NameCollectionTool.Controllers
{
    public class PersonNamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
