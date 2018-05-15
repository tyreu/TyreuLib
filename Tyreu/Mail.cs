using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System.Linq;
using System.Net.Mail;

namespace Tyreu
{
    public class EMail
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Imap { get; set; }
        public EMail(string log, string pass, string imap) { Login = log; Password = pass; Imap = imap; }
        void GetAddresses()
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL(Imap);
                imap.UseBestLogin(Login, Password);
                imap.Select("INBOX");
                var addresses = (from long uid in imap.Search(Flag.All)
                                 from to in new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid)).From
                                 from mailbox in to.GetMailboxes()
                                 select mailbox.Address).Distinct();
            }
        }
        void SendMail()
        {
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            //MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            //mail.Subject = "this is a test email.";
            //mail.Body = "this is my test email body";
            //client.Send(mail);
        }
    }
}
