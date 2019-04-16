using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantReviews.Core
{
    //public Restuarant()
    //{
    //    Reviews = new List<Restuarant> 
    //}

    public class Restuarant
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
        public ICollection<RestuarantReview> Reviews { get; set; }

    }
}
