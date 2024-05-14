using AutoMapper;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Card;
using Solution.Domain.Entities.Case;
using System.Runtime.Remoting.Messaging;

namespace Solution.BusinessLogic.Core
{
    public class CardApi
    {
        public CardResp AddCard(NewCardData data)
        {
            var newCard = Mapper.Map<CardDbTable>(data);
            var response = new CardResp();

            try
            {
                using (var db = new CardContext())
                {
                    db.Cards.Add(newCard);
                    db.SaveChanges();
                }

                response.StatusMessage = "Card added successfully!";
                response.Status = true;
            }
            catch
            {
                response.StatusMessage = "An error occured while adding card";
                response.Status = false;
            }

            return response;
        }

        public CardResp Pay(UCardData data)
        {
            var card = Mapper.Map<CardDbTable>(data);
            var response = new CardResp();

            try
            {
                response.StatusMessage = "Payment successfully!";
                response.Status = true;
            }
            catch
            {
                response.StatusMessage = "An error occured.";
                response.Status = false;
            }

            return response;
        }
    }
}
