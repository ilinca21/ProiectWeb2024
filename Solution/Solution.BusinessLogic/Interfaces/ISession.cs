using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLoginAction(ULoginData data);
    }
}
