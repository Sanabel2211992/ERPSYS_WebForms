using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Security;
namespace ERPSYS.Helpers
{
    public class EmailMessageHandle3
    {
        public string MailServer = "";
        public int ServerPort = 25;
        public string Recipient = "";
        public string Cc = "";
        public string Bcc = "";
        public string SenderEmail = "";
        public string SenderName = "";
        public string ReplyTo = "";
        public string Subject = "";
        public string Message = "";
        public string Username = "";
        public string Password = "";
        public string ContentType = "text/plain";
        public string CharacterEncoding = "8bit";
        public Encoding Encoding = Encoding.Default;
        public MailPriority Priority = MailPriority.Normal;
        public string LogFile = "";
        public bool HandleExceptions = true;
        public string ErrorMessage = "";
        public bool Error;
        public int Timeout = 30;
        public event DelSmtpNativeEvent SendComplete;
        public event DelSmtpNativeEvent MessageSendComplete;
        public event DelSmtpNativeEvent SendError;
 
        public bool Connect() 
        {
            return true;
        }
 
        public bool SendMail() 
        {
           //if (!string.IsNullOrEmpty(LogFile))
           //    LogString("\r\n*** Starting SMTP connection - " + DateTime.Now.ToString());
 
            // *** Allow for server:Port syntax (west-wind.com:1212)
            int serverPort = ServerPort;
            string server = MailServer;
 
            // *** if there's a port we need to split the address
            string[] parts = server.Split(':');
            if (parts.Length > 1) 
            {
                server = parts[0];
                serverPort = int.Parse(parts[1]);
            }
 
            if (string.IsNullOrEmpty(server)) 
            {
                SetError("No Mail Server specified.");
                return false;
            }
 
            SmtpClient smtp;
            try
            {
                smtp = new SmtpClient(server, serverPort);
            }
            catch (SecurityException)
            {
                SetError("Unable to create SmptClient due to missing permissions. If you are using a port other than 25 for your email server, SmtpPermission has to be explicitly added in Medium Trust.");
                return false;
            }
 
            // *** This is a Total Send Timeout not a Connection timeout!
            smtp.Timeout = Timeout * 1000;
 
            if (!string.IsNullOrEmpty(Username))
                smtp.Credentials = new NetworkCredential(Username, Password);
 
            // *** Create and configure the message 
            MailMessage msg = GetMessage(); 
 
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                if (SendError != null)
                    SendError(this);
 
                return false;
            }
 
            if (SendComplete != null)
                SendComplete(this);
 
            return true;
        }

        protected virtual MailMessage GetMessage()
        {
            MailMessage msg = new MailMessage();
 
            msg.Body = Message;
            msg.Subject = Subject;
            msg.From = new MailAddress(SenderEmail, SenderName);
 
            //if (!string.IsNullOrEmpty(ReplyTo))
            //    msg.ReplyTo = new MailAddress(ReplyTo);
 
            // *** Send all the different recipients
            SendRecipients(msg.To, Recipient);
            SendRecipients(msg.CC, Cc);
            SendRecipients(msg.Bcc, Bcc);
 
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    ms.Write(Encoding.GetBytes(Message));
            //    ms.Position = 0L;
 
            //    AlternateView vw = new AlternateView(ms);
            //    vw.ContentType = "text/html";
            //    vw.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
 
            //    msg.AlternateViews.Add(vw);
            //}                       
 
            //msg.Headers.Add("x-mailer", "wwSmtp .Net");
 
            if (ContentType.StartsWith("text/html"))
                msg.IsBodyHtml = true;
            else
                msg.IsBodyHtml = false;
            //msg.Headers.Add("Content-Type",ContentType);
            //msg.Headers.Add("Content-Transfer-Encoding", CharacterEncoding);
 
            msg.Priority = Priority;
 
            msg.BodyEncoding = Encoding;
 
            return msg;
        }
 
        void SendRecipients(MailAddressCollection address, string recipients)
        {
            if (string.IsNullOrEmpty(recipients))
                return;
 
            string[] recips = recipients.Split(',', ';');
 
            foreach (string t in recips)
            {
                address.Add(new MailAddress(t));
            }
        }

        public string GetEmailFromFullAddress(string fullEmail)
        {
            if (fullEmail.IndexOf("<", StringComparison.Ordinal) > 0)
            {
                int lnIndex = fullEmail.IndexOf("<", StringComparison.Ordinal);
                int lnIndex2 = fullEmail.IndexOf(">", StringComparison.Ordinal);
                string lcEmail = fullEmail.Substring(lnIndex + 1, lnIndex2 - lnIndex - 1);
                return lcEmail;
            }
 
            return fullEmail;
        }
 
        public void SendMailAsync() 
        {
            ThreadStart delSendMail = SendMailRun;
            delSendMail.BeginInvoke(null, null);
 
//            Thread mailThread = new Thread(delSendMail);
//            mailThread.Start();
        }
 
        protected void SendMailRun() 
        {
            // Create an extra reference to insure GC doesn't collect
            // the reference from the caller
            EmailMessageHandle3 email = this;  
            email.SendMail();
        }
 
        protected void LogString(string message)
        {
            if (string.IsNullOrEmpty(LogFile))
                return;
 
            if (!message.EndsWith("\r\n"))
                message += "\r\n";
 
            using (StreamWriter sw = new StreamWriter(LogFile, true))
            {
                sw.Write(message);
            }
        }
 

        private void SetError(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage)) 
            {
                ErrorMessage = "";
                Error = false;
                return;
            }
 
            ErrorMessage = errorMessage;
            Error = true;
        }

        protected virtual void OnMessageSendComplete(EmailMessageHandle3 smtp)
        {
            var handler = MessageSendComplete;
            if (handler != null) handler(smtp);
        }
    }
 
    public delegate void DelSmtpNativeEvent(EmailMessageHandle3 smtp);
 
}
