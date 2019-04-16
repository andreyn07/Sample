using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantReviews.Core
{
    public class RestuarantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string ReviewerName { get; set; }
        public int RestuarantId { get; set; }
        public DateTime ReviewDate { get; set; }
        public Restuarant Restuarant { get; set; }
    }
}
