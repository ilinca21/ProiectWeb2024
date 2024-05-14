using System;
using System.Collections.Generic;
using System.Data.Entity;
using Solution.Domain.Entities.Question;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.DBModel.Seed
{
    public class QuestionContext : DbContext
    {
        public QuestionContext() :
            base("name = proiect")
        {
        }

        public virtual DbSet<QuestionDbTable> Questions { get; set; }
    }
}
