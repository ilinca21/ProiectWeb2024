﻿using Solution.BusinessLogic.Core;
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
    public class SessionBL : UserApi , ISession
    {
        public ULoginResp UserLoginAction(ULoginData data)
        {
            return RLoginUpService(data);
        }
    }
}
