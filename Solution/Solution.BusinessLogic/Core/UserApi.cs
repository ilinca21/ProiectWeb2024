using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.Core
{
    public class UserApi
    {
        public ULoginResp RLoginUpService(ULoginData data)
        {

            return new ULoginResp { Status = false };
        }
    }
}
