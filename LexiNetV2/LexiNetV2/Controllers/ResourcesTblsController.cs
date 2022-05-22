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
    public class ResourcesTblsController : Controller
    {
        private LexiNetDbEntities2 db = new LexiNetDbEntities2();

        // GET: ResourcesTbls
        public ActionResult Index()
        {
            var resourcesTbls = db.ResourcesTbls.Include(r => r.UserTbl);
            return View(resourcesTbls.ToList());
        }

        // GET: ResourcesTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourcesTbl resourcesTbl = db.ResourcesTbls.Find(id);
            if (resourcesTbl == null)
            {
                return HttpNotFound();
            }
            return View(resourcesTbl);
        }

        // GET: ResourcesTbls/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username");
            return View();
        }

        // POST: ResourcesTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resourceID,resourceName,resourceType,userID")] ResourcesTbl resourcesTbl)
        {
            if (ModelState.IsValid)
            {
                db.ResourcesTbls.Add(resourcesTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", resourcesTbl.userID);
            return View(resourcesTbl);
        }

        // GET: ResourcesTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourcesTbl resourcesTbl = db.ResourcesTbls.Find(id);
            if (resourcesTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", resourcesTbl.userID);
            return View(resourcesTbl);
        }

        // POST: ResourcesTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resourceID,resourceName,resourceType,userID")] ResourcesTbl resourcesTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourcesTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.UserTbls, "userID", "username", resourcesTbl.userID);
            return View(resourcesTbl);
        }

        // GET: ResourcesTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourcesTbl resourcesTbl = db.ResourcesTbls.Find(id);
            if (resourcesTbl == null)
            {
                return HttpNotFound();
            }
            return View(resourcesTbl);
        }

        // POST: ResourcesTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourcesTbl resourcesTbl = db.ResourcesTbls.Find(id);
            db.ResourcesTbls.Remove(resourcesTbl);
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
