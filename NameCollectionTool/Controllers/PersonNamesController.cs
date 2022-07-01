using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;

namespace NameCollectionTool.Controllers
{
    public class PersonNamesController : Controller
    {
        private readonly IPersonNameService _nameService;
        private readonly IMapper _mapper;

        public PersonNamesController(IPersonNameService nameService, IMapper mapper)
        {
            _nameService = nameService;
            _mapper = mapper;
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
            [Bind("FirstName,LastName,Gender,Etymology,Tags")] PersonNameViewModel name)
        {
            if (name!= null)
            {
                if (name.Tags.First() != null)
                {
                    // Divide up the tags, trim them and add them to the tag list
                    name.Tags = name.Tags.First().Split(',').Select(x => x.Trim()).ToList();
                }
                _nameService.InsertNewName(_mapper.Map<PersonNameDto>(name));
            }

            //return View(new PersonNameViewModel());
            return RedirectToAction("Create",new { executedCreate = true });
        }

        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            _nameService.DeleteName(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
