using System;
using System.Collections.Generic;
using System.Data.Entity;
using Solution.Domain.Entities.Testimonial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.DBModel.Seed
{
    public class TestimonialContext : DbContext
    {
        public TestimonialContext() :
            base("name = proiect")
        {
        }

        public virtual DbSet<TestimonialDbTable> Testimonials { get; set; }
    }
}
