using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class MailController
    {
        public static void sendEmail(string toEmail,string subject = "No Subject",string content = "")
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("NungNingRacingShop@gmail.com", "02123456");

            MailMessage mm = new MailMessage("NungNingRacingShop@gmail.com", toEmail);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.IsBodyHtml = true;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Subject = subject;
            mm.Body = content;
            client.Send(mm);
        }
    }
}
