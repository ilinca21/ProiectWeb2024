using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.Testimonial
{
    public class NewTestimonialData
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
