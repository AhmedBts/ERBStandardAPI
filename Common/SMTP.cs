using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SMTPManager
    {
        public static bool SendSMTP(this MailMessage mailMessage, GeneralSetup generalSetup, string subject = "", string[] mailAddresses = null,string body = "")
        {
            try
            {

                mailMessage.To.Add(string.Join(",", mailAddresses));
                mailMessage.Subject=  subject;
                mailMessage.From = new MailAddress(generalSetup.Email);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.Default;
                mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, new System.Net.Mime.ContentType("text/html")));
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = generalSetup.MailHost;
                smtpClient.Port = (int)generalSetup.MailPort!;
                //"yonrftvmxugfmcsl"
                smtpClient.Credentials = new NetworkCredential(generalSetup.Email,generalSetup.AppPassword);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

    }
}
