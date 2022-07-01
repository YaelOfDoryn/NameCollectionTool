﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NameCollectionTool.Controllers
{
    public class ReffController1 : Controller
    {
        // GET: ReffController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReffController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReffController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReffController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReffController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReffController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReffController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReffController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
