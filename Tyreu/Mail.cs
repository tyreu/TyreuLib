using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tyreu
{
    public class Mail
    {
        //using (Imap imap = new Imap())
        //    {
        //        imap.ConnectSSL("imap.mail.ru");
        //        imap.UseBestLogin("login", "pass");
        //        Console.WriteLine(1);
        //        imap.Select("INBOX");
        //        Console.WriteLine(2);
        //        var addresses = (from long uid in imap.Search(Flag.All)
        //                         let email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid))
        //                         from to in email.From
        //                         from mailbox in to.GetMailboxes()
        //                         select mailbox.Address).Distinct();
        //        Console.WriteLine("{0} boxes!",addresses.Count());
        //        foreach (var item in addresses)
        //            Console.WriteLine(item);
        //        imap.Close();
        //    }
    }
}
