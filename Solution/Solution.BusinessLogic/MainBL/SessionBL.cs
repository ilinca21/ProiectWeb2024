using Solution.BusinessLogic.Core;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.MainBL
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginResp UserLoginAction(ULoginData data)
        {
            UDBTable user;

            using (var db = new UserContext())
            {
                user = (from u in db.Users where u.UserName == data.Credential select u).FirstOrDefault();
            }
            return RLoginUpService(data);
        }

        public ULoginResp RegisterNewUserAction(URegisterData regData)
        {
            return RRegisterNewUserAction(regData);
        }
    }
}
