using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ICollectionsService _collectionsService;

        public CollectionsController(ICollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }

        public IActionResult Index()
        {
            CollectionsViewModel model = new CollectionsViewModel();

            model.Statistics = _collectionsService.GetCollectionStats();

            return View(model);
        }
    }
}
