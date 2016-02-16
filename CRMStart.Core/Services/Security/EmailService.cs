using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CRMStart.Core.Services.Security
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //var objMail = new MailMessage();
            //var objSmtp = new SmtpClient();

            //objMail.From = new MailAddress("CrmStart@codecorner.co.uk");

            //objMail.IsBodyHtml = true;
            //objMail.To.Add(message.Destination);
            //objMail.Subject = message.Subject;
            //objMail.Body = message.Body;


            //return objSmtp.SendMailAsync(objMail);
            return Task.FromResult(0);
        }
    }
}