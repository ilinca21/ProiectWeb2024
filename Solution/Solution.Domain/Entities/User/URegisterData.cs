using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities.User
{
    public class URegisterData
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
