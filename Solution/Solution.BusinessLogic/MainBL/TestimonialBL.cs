using System.Collections.Generic;
using System.Linq;
using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Question;
using Solution.Domain.Entities.Testimonial;

namespace Solution.BusinessLogic.MainBL
{
    public class TestimonialBL : AdminApi, ITestimonial
    {
        private readonly TestimonialContext _context;

        public TestimonialBL()
        {
            _context = new TestimonialContext();
        }

        public TestimonialBL(TestimonialContext context)
        {
            _context = context;
        }

        public TestimonialResp AddTestimonialAction(NewTestimonialData data)
        {
            return AddTestimonial(data);
        }

        public IEnumerable<TestimonialDbTable> GetAll()
        {
            return _context.Testimonials.ToList();
        }
    }
}
