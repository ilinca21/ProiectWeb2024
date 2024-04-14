﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace proiect.VerifyRole
{
    public class IsLoginUser
    {
        public static bool IsUserLogin()
        {
           if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return true;
            }
           else
            {
                return false;
            }
        }
    }
}