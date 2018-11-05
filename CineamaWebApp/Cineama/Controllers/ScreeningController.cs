using Cineama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cineama.Controllers
{
    public class ScreeningController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Screening
        public ActionResult Index()
        {
            return View();
        }

        // GET: Screening/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Screening/Create
        public ActionResult Create()
        {
            
            List<SelectListItem> auditoriumList = new List<SelectListItem>();
            var items = db.AuditoriumModel.ToList();
            foreach (var item in items)
                auditoriumList.Add(new SelectListItem
                {
                   Text = item.id.ToString(),
                   Value = item.id.ToString()
                });
            ViewBag.AuditoriumId = auditoriumList;

            List<SelectListItem> movieList = new List<SelectListItem>();
            var movies = db.MovieModels.ToList();
            foreach (var movie in movies)
                movieList.Add(new SelectListItem
                {
                    Text = movie.movieId.ToString(),
                     Value = movie.movieId.ToString()
                });
            ViewBag.movies = movieList;


            return View();
        }

        // POST: Screening/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "playDate,MovieTitle,AuditoriumId")] ScreeningModel screening)
        {
            List<SelectListItem> movieList = new List<SelectListItem>();
            var movies = db.MovieModels.ToList();
            foreach (var movie in movies)
                movieList.Add(new SelectListItem
                {
                    Text = movie.movieId.ToString(),
                    Value = movie.movieId.ToString()
                });
            ViewBag.movies = movieList;

            List<SelectListItem> auditoriumList = new List<SelectListItem>();
            var items = db.AuditoriumModel.ToList();
            foreach (var item in items)
                auditoriumList.Add(new SelectListItem
                {
                    Text = item.id.ToString(),
                    Value = item.id.ToString()
                });
            ViewBag.AuditoriumId = auditoriumList;
            try
            {

                db.ScreeningModel.Add(screening);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Screening/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Screening/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Screening/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Screening/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
