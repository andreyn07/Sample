using RestuarantReviews.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestuarantReviews.Models
{
    public class ReviewVm
    {

        public ReviewVm()
        {
            Ratings = new List<SelectListItem>();
            Ratings.Add(new SelectListItem() { Text = "Very Bad", Value = "1" });
            Ratings.Add(new SelectListItem() { Text = "Bad", Value = "2" });
            Ratings.Add(new SelectListItem() { Text = "Aight", Value = "3" });
            Ratings.Add(new SelectListItem() { Text = "Good", Value = "4" });
            Ratings.Add(new SelectListItem() { Text = "Very Good", Value = "5" });

        }

        public int Id { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string ReviewerName { get; set; }
        public int RestuarantId { get; set; }
        public DateTime ReviewDate { get; set; }
        public List<SelectListItem> Ratings { get; set; }
    }
}