using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiNetV2;

namespace LexiNetV2.Views
{
    public class resourceReviewsBsController : Controller
    {
        private LexiNetDbEntities2 db = new LexiNetDbEntities2();

        // GET: resourceReviewsBs
        public ActionResult Index()
        {
            return View(db.resourceReviewsBs.ToList());
        }

        // GET: resourceReviewsBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resourceReviewsB resourceReviewsB = db.resourceReviewsBs.Find(id);
            if (resourceReviewsB == null)
            {
                return HttpNotFound();
            }
            return View(resourceReviewsB);
        }

        // GET: resourceReviewsBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resourceReviewsBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resourceName,resourceType,readabilityRating,spacingRating,colourRating")] resourceReviewsB resourceReviewsB)
        {
            if (ModelState.IsValid)
            {
                db.resourceReviewsBs.Add(resourceReviewsB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceReviewsB);
        }

        // GET: resourceReviewsBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resourceReviewsB resourceReviewsB = db.resourceReviewsBs.Find(id);
            if (resourceReviewsB == null)
            {
                return HttpNotFound();
            }
            return View(resourceReviewsB);
        }

        // POST: resourceReviewsBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resourceName,resourceType,readabilityRating,spacingRating,colourRating")] resourceReviewsB resourceReviewsB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceReviewsB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceReviewsB);
        }

        // GET: resourceReviewsBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resourceReviewsB resourceReviewsB = db.resourceReviewsBs.Find(id);
            if (resourceReviewsB == null)
            {
                return HttpNotFound();
            }
            return View(resourceReviewsB);
        }

        // POST: resourceReviewsBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            resourceReviewsB resourceReviewsB = db.resourceReviewsBs.Find(id);
            db.resourceReviewsBs.Remove(resourceReviewsB);
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
