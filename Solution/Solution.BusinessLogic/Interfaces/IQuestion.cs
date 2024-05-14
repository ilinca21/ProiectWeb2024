using System.Collections.Generic;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Case;
using Solution.Domain.Entities.Question;

namespace Solution.BusinessLogic.Interfaces
{
    public interface IQuestion
    {
        QuestionResp AddQuestionAction(NewQuestionData data);

        IEnumerable<QuestionDbTable> GetAll();
    }
}
