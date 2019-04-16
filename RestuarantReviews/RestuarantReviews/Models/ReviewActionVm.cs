using RestuarantReviews.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestuarantReviews.Helpers;

namespace RestuarantReviews.Models
{
    public class ReviewActionVm
    {
        public enum ReviewDisplayType
        {
            Latest,
            Best,
            Worst
        }
        public int? RestaurantId { get; set; }
        public ReviewDisplayType Type { get; set; }
    }
}