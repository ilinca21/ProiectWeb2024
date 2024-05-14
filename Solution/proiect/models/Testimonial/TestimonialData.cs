using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect.Models.Testimonial
{
    public class TestimonialData
    {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public HttpPostedFileBase ImageFile { get; set; }
            public int UserId { get; set; }
    }
}