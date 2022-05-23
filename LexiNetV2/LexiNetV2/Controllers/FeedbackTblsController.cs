using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiNetV2;

namespace LexiNetV2.Controllers
{
    public class FeedbackTblsController : Controller
    {
        private LexiNetDbEntities2 db = new LexiNetDbEntities2();

        // GET: FeedbackTbls
        public ActionResult Index()
        {
            var feedbackTbls = db.FeedbackTbls.Include(f => f.ResourcesTbl).Include(f => f.UserTbl);
            return View(feedbackTbls.ToList());
        }

        // GET: FeedbackTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackTbl feedbackTbl = db.FeedbackTbls.Find(id);
            if (feedbackTbl == null)
            {
                return HttpNotFound();
            }
            return View(feedbackTbl);
        }

        // GET: FeedbackTbls/Create
        public ActionResult Create()
        {
            ViewBag.resourceID = new SelectList(db.ResourcesTbls, "resourceID", "resourceName");
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username");
            return View();
        }

        // POST: FeedbackTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feebackID,readabilityRating,spacingRating,colourRating,userID,resourceID")] FeedbackTbl feedbackTbl)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackTbls.Add(feedbackTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resourceID = new SelectList(db.ResourcesTbls, "resourceID", "resourceName", feedbackTbl.resourceID);
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", feedbackTbl.userID);
            return View(feedbackTbl);
        }

        // GET: FeedbackTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackTbl feedbackTbl = db.FeedbackTbls.Find(id);
            if (feedbackTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.resourceID = new SelectList(db.ResourcesTbls, "resourceID", "resourceName", feedbackTbl.resourceID);
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", feedbackTbl.userID);
            return View(feedbackTbl);
        }

        // POST: FeedbackTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feebackID,readabilityRating,spacingRating,colourRating,userID,resourceID")] FeedbackTbl feedbackTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resourceID = new SelectList(db.ResourcesTbls, "resourceID", "resourceName", feedbackTbl.resourceID);
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", feedbackTbl.userID);
            return View(feedbackTbl);
        }

        // GET: FeedbackTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackTbl feedbackTbl = db.FeedbackTbls.Find(id);
            if (feedbackTbl == null)
            {
                return HttpNotFound();
            }
            return View(feedbackTbl);
        }

        // POST: FeedbackTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackTbl feedbackTbl = db.FeedbackTbls.Find(id);
            db.FeedbackTbls.Remove(feedbackTbl);
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
