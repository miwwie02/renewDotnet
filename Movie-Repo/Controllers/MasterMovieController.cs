using Microsoft.AspNetCore.Mvc;
using Movie_Repo.Models;
using Movie_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Repo.Controllers
{
    public class MasterMovieController : Controller
    {
        private readonly IMasterMovieService _masterMovieService;

        public MasterMovieController(IMasterMovieService masterMovieService)
        {
            _masterMovieService = masterMovieService;
        }

        // GET: MasterMovieController
        public ActionResult Index()
        {
            var movies = _masterMovieService.GetAll();
            return View(movies);
        }

        // GET: MasterMovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.AddMovie(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterMovieController/Edit/5
        public ActionResult Edit(int id)
        {
            MasterMovie item = _masterMovieService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.UpdateMovie(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // POST: MasterMovieController/Delete/5
        public ActionResult Delete(int id)
        {
            _masterMovieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
