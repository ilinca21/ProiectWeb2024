using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.MainBL
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public IUserMonitoring GetMonitoringBL()
        {
            return new MonitoringBL();
        }
        public ICase GetCaseBL()
        {
            return new CaseBL();
        }

        public ICard GetCardBL()
        {
            return new CardBL();
        }

        public IQuestion GetQuestionBL()
        {
            return new QuestionBL();
        }

        public ITestimonial GetTestimonialBL()
        {
            return new TestimonialBL();
        }     
    }
}


