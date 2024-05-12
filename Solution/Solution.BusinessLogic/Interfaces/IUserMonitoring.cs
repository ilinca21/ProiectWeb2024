using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.Interfaces
{
    public interface IUserMonitoring
    {
        List<UserMinimal> GetAllUsers();
        ULoginResp AddNewUser(ANewUser addData);
        UserMinimal RGetUserById(int id);
        void EditUser(int id, UserMinimal user);
    }
}
