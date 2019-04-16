using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RestuarantReviews.Models
{
    public class RestuarantListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }

        public int CountOfReviews { get; set; }
        public double AverageScore { get; set; }
        private static string FormatedUrl(string website)
        {
            if (!string.IsNullOrEmpty(website) && !website.StartsWith("http"))
            {
                website = "http://" + website;
            }
            return website;
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
    }
}