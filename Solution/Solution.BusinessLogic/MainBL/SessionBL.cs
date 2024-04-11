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
using System.Web;

namespace Solution.BusinessLogic.MainBL
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginResp UserLoginAction(ULoginData data)
        {
            return RLoginUpService(data);
        }

        public ULoginResp RegisterNewUserAction(URegisterData regData)
        {
            return RRegisterNewUserAction(regData);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
