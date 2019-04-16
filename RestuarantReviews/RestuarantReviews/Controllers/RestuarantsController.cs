using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestuarantReviews.Core;
using RestuarantReviews.DB;

namespace RestuarantReviews.Controllers
{   [Authorize]
    public class RestuarantsController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: Restuarants
        public ActionResult Index()
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    using (var db = new ReviewContext())
            //    {
            //        db.Restuarants.Add(
            //            new Restuarant()
            //            {
            //                Name = "Restaurant " + i,
            //                Address = i + " Test Ave",
            //                City = "Philadelphia",
            //                State = "PA",
            //                Zip = "19111",
            //                Phone = $"(215) 555-{string.Join("", Enumerable.Repeat(i, 4).ToArray()).Substring(0, 4)}",
            //                Website = i + ".test.com",
            //                Country = "USA"
            //            });
            //db.SaveChanges();
            //    }
            //}
            return View(db.Restuarants.ToList());
        }

        // GET: Restuarants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // GET: Restuarants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restuarants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,City,State,Zip,Phone,Website,Country,ImageUrl")] Restuarant restuarant)
        {
            if (ModelState.IsValid)
            {
                db.Restuarants.Add(restuarant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restuarant);
        }

        // GET: Restuarants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Restuarants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restuarant restuarant, HttpPostedFileBase restuarantImage)
        {
            bool isValidDoc = false;
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
            if (ModelState.IsValid)
            {

                if (restuarantImage != null && restuarantImage.ContentLength > 0)
                {
                    isValidDoc = formats.Any(
                        p => restuarantImage.FileName.EndsWith(p, StringComparison.OrdinalIgnoreCase));
                }

                if (isValidDoc)
                {
                    restuarant.ImageUrl = Path.GetFileName(restuarantImage.FileName);
                }

                if (restuarant.Id == 0)
                {
                    db.Restuarants.Add(restuarant);
                }
                else
                {
                    db.Entry(restuarant).State = EntityState.Modified;
                }

                db.SaveChanges();

                if (isValidDoc)
                {
                    var fileDirectory =
                    Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["RestuarantImageUploadBase"]), restuarant.Id.ToString());

                    Directory.CreateDirectory(fileDirectory);

                    var filePath = Path.Combine(fileDirectory, restuarant.ImageUrl);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    restuarantImage.SaveAs(filePath);
                }
                return RedirectToAction("Index");
            }
            return View(restuarant);
        }

        // GET: Restuarants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restuarant restuarant = db.Restuarants.Find(id);
            if (restuarant == null)
            {
                return HttpNotFound();
            }
            return View(restuarant);
        }

        // POST: Restuarants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restuarant restuarant = db.Restuarants.Find(id);
            db.Restuarants.Remove(restuarant);
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
