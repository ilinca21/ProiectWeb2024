using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiect.Models.User
{
    public class UserRegister
    {
        public string Credential { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}