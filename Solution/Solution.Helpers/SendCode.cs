using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Helpers
{
    public class SendCode
    {
        static public string SendCodeToUser(string strEmail)
        {
            string codeRandom = GenerateRandomCode.GenerateRandom(8);
            SendEmail.SendEmailCode(strEmail, codeRandom);
            return codeRandom;
        }
    }
}
