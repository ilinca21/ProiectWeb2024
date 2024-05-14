using System;
using System.Collections.Generic;
using System.Data.Entity;
using Solution.Domain.Entities.Session;
using Solution.Domain.Entities.Case;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.DBModel.Seed
{
    public class CaseContext : DbContext
    {
        public CaseContext() :
            base("name = proiect")
        {
        }

        public virtual DbSet<CaseDbTable> Cases { get; set; }
    }
}
