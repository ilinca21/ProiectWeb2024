using Solution.Domain.Entities.Card;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.DBModel.Seed
{
    public class CardContext : DbContext
    {
        public CardContext() :
            base("name = proiect")
        {
        }

        public virtual DbSet<CardDbTable> Cards { get; set; }
    }
}
