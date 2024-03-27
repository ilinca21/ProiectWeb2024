using Solution.BusinessLogic.DBModel.Seed;
using Solution.Domain.Entities.DonatorType;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using Solution.Domain.Enums;
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
            //Step 1 - SELECT FROM DB>Users WHERE data.
            // PASSWORD == data.Password

            //Step 2 - IF object != NULL
            // CREATE SESSION

            //RETURN SESSION AND STATUS TRUE

            UDBTable user;
            using (var db = new UserContext() )
            {
               user = db.Users.FirstOrDefault(us => us.UserName == data.Credential);
                if(user == null) return new ULoginResp { Status = false };
                if (user.Password == data.Password) return new ULoginResp { Status = true };
            }

            return new ULoginResp { Status = false };
        }

        internal ULoginResp RRegisterNewUserAction(URegisterData data)
        {
            var newUser = new UDBTable
            {
                UserName = data.UserName,
                Password = data.Password,
                LastIp = "",
                LastLogin = DateTime.Now,
                Level = UserRole.User
            };

            using (var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            return new ULoginResp();
        }
        public DonatorTypeDetail GetBloodTypeUser(int id)
        {
            return new DonatorTypeDetail();
        }
    }
}
