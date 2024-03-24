using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.DonatorType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.MainBL
{
    public class DonatorTypeBL : UserApi, IDonatorType
    {
        public DonatorTypeDetail GetDetailDonatorType (int id)
        {
            return GetDonatorTypeUser(id);        }

        private DonatorTypeDetail GetDonatorTypeUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
