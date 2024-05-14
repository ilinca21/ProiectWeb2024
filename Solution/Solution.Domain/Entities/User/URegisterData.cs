﻿using Solution.Domain.Enums;
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
        public string Credential { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string LoginIp { get; set; }

        public DateTime LoginDateTime { get; set; }

        public string Email { get; set; }
        public UserRole Level { get; set; }
    }
}
