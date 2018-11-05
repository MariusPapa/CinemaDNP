using Cineama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cineama.Controllers
{
    public class AuditoriumController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auditorium
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auditorium/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auditorium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditorium/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,seats")] AuditoriumModel auditorium)
        {
            try
            {
                // TODO: Add insert logic here
                db.AuditoriumModel.Add(auditorium);
                db.SaveChanges();

                return RedirectToAction("Create");
            }
            catch
            {
                return View(auditorium);
            }
        }

        // GET: Auditorium/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auditorium/Edit/5
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

        // GET: Auditorium/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auditorium/Delete/5
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
