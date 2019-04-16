using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RestuarantReviews.Core;
using RestuarantReviews.DB;
using RestuarantReviews.Models;

namespace RestuarantReviews.Controllers
{
    public class RestuarantReviewsController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: RestuarantReviews
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Restuarants");
            }

            var restuarant = db.Restuarants.Include(r => r.Reviews).FirstOrDefault(p => p.Id == id);

            return View(restuarant);

        }

        ////GET: Best, Worst and Latest Reviews
        [ChildActionOnly]
        public ActionResult Review(ReviewActionVm model)
        {
            IQueryable<RestuarantReview> review = db.RestuarantReview.Include(p => p.Restuarant);

            if (model.RestaurantId.HasValue)
            {
                review = review.Where(p => p.RestuarantId == model.RestaurantId).AsQueryable();
            }
            switch (model.Type)
            {
                case ReviewActionVm.ReviewDisplayType.Latest:
                    review = review.OrderByDescending(p => p.ReviewDate);
                    break;
                case ReviewActionVm.ReviewDisplayType.Best:
                    review = review.OrderByDescending(p => p.Rating);
                    break;
                case ReviewActionVm.ReviewDisplayType.Worst:
                    review = review.OrderBy(p => p.Rating);
                    break;
            }

            return PartialView("_Reviews",review.FirstOrDefault());
        }

        // GET: RestuarantReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestuarantReview restuarantReview = db.RestuarantReview.Find(id);
            if (restuarantReview == null)
            {
                return HttpNotFound();
            }
            return View(restuarantReview);
        }

        // GET: RestuarantReviews/Create
        public ActionResult Create(int restuarantId)
        {
            var model = new RestuarantReview() { RestuarantId = restuarantId };
            if (Request.IsAuthenticated)
            {
                model.ReviewerName = User.Identity.GetUserName();
            }
            return View(model);
        }

        // POST: RestuarantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RestuarantReview restuarantReview)
        {
            if (ModelState.IsValid)
            {
                restuarantReview.ReviewDate = DateTime.Now;
                db.RestuarantReview.Add(restuarantReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restuarantReview);
        }

        // GET: RestuarantReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestuarantReview review = db.RestuarantReview.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(new ReviewVm()
            {
                Id = review.Id,
                Body = review.Body,
                ReviewDate = review.ReviewDate,
                ReviewerName = review.ReviewerName
            });
        }

        // POST: RestuarantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReviewVm model)
        {
            if (ModelState.IsValid)
            {
                RestuarantReview entity = db.RestuarantReview.Find(model.Id);
                entity.Body = model.Body;
                entity.Rating = model.Rating;
                entity.ReviewDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: RestuarantReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestuarantReview restuarantReview = db.RestuarantReview.Find(id);
            if (restuarantReview == null)
            {
                return HttpNotFound();
            }
            return View(restuarantReview);
        }

        // POST: RestuarantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestuarantReview restuarantReview = db.RestuarantReview.Find(id);
            db.RestuarantReview.Remove(restuarantReview);
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
