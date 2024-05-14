using AutoMapper;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Case;
using Solution.Domain.Entities.Question;

namespace Solution.BusinessLogic.Core
{
    public class QuestionApi
    {
        public QuestionResp AddQuestion(NewQuestionData data)
        {
            var newCase = Mapper.Map<QuestionDbTable>(data);
            var response = new QuestionResp();

            try
            {
                using (var db = new QuestionContext())
                {
                    db.Questions.Add(newCase);
                    db.SaveChanges();
                }

                response.StatusMessage = "Question added successfully!";
                response.Status = true;
            }
            catch
            {
                response.StatusMessage = "An error occured while adding question.";
                response.Status = false;
            }

            return response;
        }
    }
}
