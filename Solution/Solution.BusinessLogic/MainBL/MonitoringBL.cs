using Solution.BusinessLogic.Core;
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
    public class MonitoringBL : AdminApi, IUserMonitoring
    {
        public List<UserMinimal> GetAllUsers()
        {
            return RGetAllUsers();
        }

        public UserMinimal GetUserById(int id)
        {
            return RGetUserById(id);
        }

        public void EditUser(int id, UserMinimal user)
        {
            REditUser(id, user);
        }
        public ULoginResp AddNewUser(ANewUser addData)
        {
            return AddNewUserAction(addData);
        }
    }
}
