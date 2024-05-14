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
        private readonly UserContext _context;

        public SessionBL()
        {
            _context = new UserContext();
        }

        public SessionBL(UserContext context)
        {
            _context = context;
        }
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
        public UserEditData GetUserById(int userId)
        {
            return ReturnUserById(userId);
        }

        public UserResp EditProfileAction(UserEditData existingUser)
        {
            return ReturnEditedProfile(existingUser);
        }
    }
}
