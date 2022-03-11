using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Authentication.WebApi.Sender
{
    public class EmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var from = new MailAddress("ElectronicDiary2022@gmail.com", "ElectronicDiary");
            var to = new MailAddress(email); //order.User.Email   AndrewT_87@tut.by
            var mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = false;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("ElectronicDiary2022@gmail.com", "!23QweAsd");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                await smtp.SendMailAsync(mail);
            }
        }
    }
}
