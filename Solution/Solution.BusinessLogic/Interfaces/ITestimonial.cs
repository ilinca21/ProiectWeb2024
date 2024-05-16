using System.Collections.Generic;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Testimonial;

namespace Solution.BusinessLogic.Interfaces
{
    public interface ITestimonial
    {
        TestimonialResp AddTestimonialAction(NewTestimonialData data);
        IEnumerable<TestimonialDbTable> GetAll();
        TestimonialDbTable GetById(int testimonialId);
        void Delete(int testimonialId);
        void Save();
    }
}