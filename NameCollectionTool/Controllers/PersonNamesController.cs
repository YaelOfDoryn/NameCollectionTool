using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Controllers
{
    public class PersonNamesController : Controller
    {
        private readonly IPersonNameService _nameService;

        public PersonNamesController(IPersonNameService nameService)
        {
            _nameService = nameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: PersonNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("FirstName,LastName,Gender,Etymology,Tags")] PersonNameViewModel personName)
        {
            return View();
        }
    }
}
