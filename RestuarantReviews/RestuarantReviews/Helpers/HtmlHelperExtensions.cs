using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RestuarantReviews.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString Ratings(this HtmlHelper helper, double rating)
        {
            if (rating > 0)
            {
                StringBuilder sb = new StringBuilder();

                var formattedRating = Math.Round(rating * 2, MidpointRounding.AwayFromZero) / 2;
                sb.Append($"<img src='/images/stars{formattedRating * 10}.gif' />");
                return new HtmlString(sb.ToString());
            }

            else
            {
                return new HtmlString($"");
            }
        }
    }
}