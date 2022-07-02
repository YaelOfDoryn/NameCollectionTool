﻿using Microsoft.AspNetCore.Mvc;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;
using NameCollectionTool.Services.Interfaces;
using Newtonsoft.Json;

namespace NameCollectionTool.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ICollectionsService _collectionsService;
        private readonly IPersonNameService _personNamesService;
        private readonly IPlaceNamesService _placeNamesService;

        public CollectionsController(ICollectionsService collectionsService, IPersonNameService personNamesService, IPlaceNamesService placeNamesService)
        {
            _collectionsService = collectionsService;
            _personNamesService = personNamesService;
            _placeNamesService = placeNamesService;
        }

        public IActionResult Index()
        {
            CollectionsViewModel model = new CollectionsViewModel();

            model.Statistics = _collectionsService.GetCollectionStats();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPersonNames(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    try
                    {
                        StreamReader reader = new StreamReader(formFile.OpenReadStream());
                        _personNamesService.InsertNewNames(JsonConvert.DeserializeObject<List<PersonNameDto>>(reader.ReadToEnd()));
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            return RedirectToAction("Index", "Collections");
        }

        [HttpPost]
        public async Task<IActionResult> UploadPlaceNames(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    try
                    {
                        StreamReader reader = new StreamReader(formFile.OpenReadStream());
                        _placeNamesService.InsertNewNames(JsonConvert.DeserializeObject<List<PlaceNameDto>>(reader.ReadToEnd()));
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            return RedirectToAction("Index", "Collections");
        }
    }
}
