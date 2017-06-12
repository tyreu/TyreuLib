using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System.Linq;

namespace Tyreu
{
    public class EMail
    {
        string login, password, imap;
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Imap { get => imap; set => imap = value; }
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
                                 select mailbox.Address).Distinct();            }
        }
    }
}
