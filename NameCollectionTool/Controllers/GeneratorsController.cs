using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Controllers
{
    public class GeneratorsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonNameService _personNameService;
        private readonly IPlaceNamesService _placeNameService;

        public GeneratorsController(ILogger<HomeController> logger, IConfiguration iConfig, IPersonNameService personNameService, IPlaceNamesService placeNameService)
        {
            _logger = logger;
            _personNameService = personNameService;
            _placeNameService = placeNameService;
        }
        public IActionResult Index()
        {
            PersonGenerateParams model = new PersonGenerateParams();

            //model.PersonNames = _personNameService.GetAllPersonNames();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GeneratePersonName(
            [Bind("CanBeMale, CanBeUnisex, CanBeFemale")] PersonGenerateParams generateRequest)
        {
            generateRequest.PersonNames = _personNameService.GetGeneratedPersonNames(5, generateRequest);
            
            return View("Index", generateRequest);
        }
    }
}
