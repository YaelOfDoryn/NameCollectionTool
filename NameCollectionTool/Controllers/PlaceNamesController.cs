using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Controllers
{
    public class PlaceNamesController : Controller
    {
        private readonly IPlaceNamesService _nameService;

        public PlaceNamesController(IPlaceNamesService nameService)
        {
            _nameService = nameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: PersonNames/Create
        public IActionResult Create(bool executedCreate = false)
        {
            if (executedCreate)
            {
                ViewBag.toast = "Name added to the collection!";
            }
            
            return View();
        }

        // POST: PersonNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("Name,Tags")] PlaceNameViewModel placeName)
        {
            _nameService.InsertNewName(placeName);

            return RedirectToAction("Create",new { executedCreate = true });
        }

        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            _nameService.DeleteName(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
