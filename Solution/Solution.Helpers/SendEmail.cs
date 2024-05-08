using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Helpers
{
    public class SendEmail
    {
        public static void SendEmailCode(string strEmail, string strRandomPassword)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("salveazaoviata@mail.ru"); 
            message.To.Add(new MailAddress(strEmail));
            message.Subject = "Password Reset";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "Here is your key to reset your password. Key: " + strRandomPassword;
            smtp.Port = 587;
            smtp.Host = "smtp.mail.ru"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("salveazaoviata@mail.ru", "r0ScK3xWwCM6vShHugp6\r\n");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
