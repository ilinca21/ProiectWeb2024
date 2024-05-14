using System.Collections.Generic;
using System.Linq;
using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Question;

namespace Solution.BusinessLogic.MainBL
{
    public class QuestionBL : QuestionApi, IQuestion
    {
        private readonly QuestionContext _context;

        public QuestionBL()
        {
            _context = new QuestionContext();
        }

        public QuestionBL(QuestionContext context)
        {
            _context = context;
        }

        public QuestionResp AddQuestionAction(NewQuestionData data)
        {
            return AddQuestion(data);
        }

        public IEnumerable<QuestionDbTable> GetAll()
        {
            return _context.Questions.ToList();
        }
    }
}
