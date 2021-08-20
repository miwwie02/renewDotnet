using Microsoft.AspNetCore.Mvc;
using Movie_Repo.Models;
using Movie_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Controllers
{
    public class MasterTypeController : Controller
    {
        private readonly IMasterTypeService _masterTypeService;

        public MasterTypeController(IMasterTypeService masterTypeService)
        {
            _masterTypeService = masterTypeService;
        }

        // GET: MasterTypeController
        public ActionResult Index()
        {
            var Types = _masterTypeService.GetAll();
            return View(Types);
        }

        // GET: MasterTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterType item)
        {
            if (ModelState.IsValid)
            {
                _masterTypeService.AddType(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            MasterType item = _masterTypeService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: MasterTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterType item)
        {
            if (ModelState.IsValid)
            {
                _masterTypeService.UpdateType(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // POST: MasterTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            _masterTypeService.DeleteType(id);
            return RedirectToAction("Index");
        }
    }
}
