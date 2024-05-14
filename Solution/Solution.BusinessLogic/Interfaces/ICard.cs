using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Card;

namespace Solution.BusinessLogic.Interfaces
{
    public interface ICard
    {
        CardResp AddCardAction(NewCardData data);

        CardDbTable GetByUserId(int userId);

        CardResp PayAction(UCardData data);
    }
}