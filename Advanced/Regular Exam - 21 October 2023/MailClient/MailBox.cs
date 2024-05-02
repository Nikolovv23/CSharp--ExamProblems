using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity {  get; set; } 
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>(capacity);
            Archive = new List<Mail>();
        }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count == Capacity)
            {
                return;
            }
            Inbox.Add(mail);
        }
        public bool DeleteMail(string sender)
        {
            foreach (Mail mail in Inbox)
            {
                if (mail.Sender == sender)
                {
                    Inbox.Remove(mail);
                    return true;
                }
            }
            return false;
        }
        public int ArchiveInboxMessages()
        {
            int movedMmailCount = 0;
            foreach(Mail mail in Inbox)
            {
                Archive.Add(mail);
                movedMmailCount++;
            }
            Inbox.Clear();
            return movedMmailCount;
        }
        public string GetLongestMessage()
        {
            Mail longestMail = Inbox[1];
            foreach (Mail mail in Inbox)
            {
                if (mail.Body.Length >= longestMail.Body.Length)
                {
                    longestMail = mail;
                }
            }
            return longestMail.ToString();
        }
        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");

            foreach(Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
