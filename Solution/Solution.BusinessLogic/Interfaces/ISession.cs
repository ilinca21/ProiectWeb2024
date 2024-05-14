using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Solution.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLoginAction(ULoginData data);
        ULoginResp RegisterNewUserAction(URegisterData regData);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string value);
        UserEditData GetUserById(int userId);
        UserResp EditProfileAction(UserEditData existingUser);
    }
}
