using RestuarantReviews.DB;
using RestuarantReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Configuration;
using RestuarantReviews.Core;

namespace RestuarantReviews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search = null, string city= null)
        {
            using (var db = new ReviewContext())
            {
                var cities = db.Restuarants.Select(p => p.City).Distinct();
                //var cities2 = db.Restuarants.Where(p => p.City != null).GroupBy(p=> new {City = p.Id, Count = p.Count() }).ToList();

                var model = new List<RestuarantListViewModel>();
                var path = ConfigurationManager.AppSettings["RestuarantImageUploadBase"];
                List<Restuarant> restuarants = new List<Restuarant>();
                if (city != null)
                {
                    restuarants = db.Restuarants.Include(p => p.Reviews).Where(p => p.City.Contains(city)).ToList();
                }

                if (search != null)
                {
                    restuarants = db.Restuarants.Include(p => p.Reviews).Where(p => p.Name.Contains(search)).ToList();
                }
                
                else
                {
                    restuarants = db.Restuarants.Include(p => p.Reviews).ToList();
                }

                foreach (var r in restuarants)
                {
                    var vm = new RestuarantListViewModel()
                    {
                        Id=r.Id,
                        ImageUrl = GetImageUrl(r.ImageUrl, r.Id),
                        Phone = r.Phone,
                        Address = r.Address,
                        Name = r.Name,
                        Website = FormatedUrl(r.Website),
                        CountOfReviews = r.Reviews.Count(),
                        AverageScore = r.Reviews.Any() ? Math.Round(r.Reviews.Average(rv => rv.Rating), 1) : 0
                    };
                    model.Add(vm);
                }
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Restaurants", model);
                }
                return View(model);
            }

        }

        private string GetImageUrl(string imageUrl, int id)
        {
            var imageUrlFormated = "/images/download.png";
            if (!string.IsNullOrEmpty(imageUrl))
            {
                imageUrlFormated =
                    $"{ConfigurationManager.AppSettings["RestuarantImageUploadBase"].Replace("~", "")}/{id}/{imageUrl}";
            }
            return imageUrlFormated;
        }
        private static string FormatedUrl(string website)
        {
            if (!string.IsNullOrEmpty(website) && !website.StartsWith("http"))
            {
                website = "http://" + website;
            }
            return website;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Test()
        {
            using (var db = new ReviewContext())
            {
                var restuarants = db.Restuarants.ToList();
                return View(restuarants);
            }
        }
    }
}