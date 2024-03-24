using Solution.Domain.Entities.DonatorType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.Interfaces
{
    public interface IDonatorType
    {
        DonatorTypeDetail GetDetailDonatorType(int id);
    }
}
