using Microsoft.AspNetCore.Mvc;

namespace NameCollectionTool.Controllers
{
    public class GeneratorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
