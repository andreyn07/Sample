using RestuarantReviews.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantReviews.DB
{
    public class ReviewContext : DbContext
    {
        public ReviewContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<RestuarantReview> RestuarantReview { get; set; }
    }
}
