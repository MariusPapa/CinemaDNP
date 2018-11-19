using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cineama.Models;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;


namespace Cineama.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movie
        public ActionResult Index()
        {
            return View(db.MovieModels.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.MovieModels.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // GET: Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movieId,title,posterUrl,trailer,directors,actors,description")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                db.MovieModels.Add(movieModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieModel);
        }

        // GET: Movie/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.MovieModels.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);


        }
        /*
        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "title,posterUrl,trailer,directors,actors,description")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieModel);



        }
        */
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, byte[] rowVersion)
        {
            string[] fieldsToBind = new string[] { "title","posterUrl","trailer","directors","actors","description", "RowVersion" };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieModel movieModelToUpdate = await db.MovieModels.FindAsync(id);
            if (movieModelToUpdate == null)
            {
                MovieModel deletedMovie = new MovieModel();
                TryUpdateModel(deletedMovie, fieldsToBind);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The movie was deleted by another user.");
                ViewBag.movieId = new SelectList(db.MovieModels, "movieId", "title", deletedMovie.movieId);
                return View(deletedMovie);
            }

            if (TryUpdateModel(movieModelToUpdate, fieldsToBind))
            {
                try
                {
                    db.Entry(movieModelToUpdate).OriginalValues["RowVersion"] = rowVersion;
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var clientValues = (MovieModel)entry.Entity;
                    var databaseEntry = entry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The movie was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (MovieModel)databaseEntry.ToObject();

                        if (databaseValues.title != clientValues.title)
                            ModelState.AddModelError("Name", "Current value: "
                                + databaseValues.title);
                        if (databaseValues.posterUrl != clientValues.posterUrl)
                            ModelState.AddModelError("Poster url", "Current value: "
                                + databaseValues.posterUrl);
                        if (databaseValues.trailer != clientValues.trailer)
                            ModelState.AddModelError("Trailer url", "Current value: "
                                +  databaseValues.trailer);
                        if (databaseValues.directors != clientValues.directors)
                            ModelState.AddModelError("Directors", "Current value: "
                                + databaseValues.directors);
                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                            + "was modified by another user after you got the original value. The "
                            + "edit operation was canceled and the current values in the database "
                            + "have been displayed. If you still want to edit this record, click "
                            + "the Save button again. Otherwise click the Back to List hyperlink.");
                        movieModelToUpdate.RowVersion = databaseValues.RowVersion;
                    }
                }
                catch (RetryLimitExceededException )
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
           //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
            return View(movieModelToUpdate);
        }

        
    

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.MovieModels.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieModel movieModel = db.MovieModels.Find(id);
            db.MovieModels.Remove(movieModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
