using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.MainBL
{
    public class CardBL : CardApi, ICard
    {
        private readonly CardContext _context;

        public CardBL()
        {
            _context = new CardContext();
        }

        public CardBL(CardContext context)
        {
            _context = context;
        }

        public CardResp AddCardAction(NewCardData data)
        {
            return AddCard(data);
        }

        public CardResp PayAction(UCardData data)
        {
            return Pay(data);
        }

        public CardDbTable GetByUserId(int userId)
        {
            return _context.Cards.Find(userId);
        }
    }
}
