//using System;
//using System.IO;
//using System.Net;
//using System.Net.Mail;

//namespace ERPSYS.Helpers.BK
//{
//    public class ClsEmail2
//    {
//        private readonly string _smtpServer;
//        private readonly bool _smtpRequiresAuthentication = false;
//        private readonly string _smtpUsername = "";
//        private readonly string _smtpPassword = "";

//        public ClsEmail2(string smtpServer, bool smtpRequiresAuthentication)
//        {
//            _smtpServer = smtpServer;
//            _smtpRequiresAuthentication = smtpRequiresAuthentication;
//        }

//        public ClsEmail2(string smtpServer, bool smtpRequiresAuthentication, string smtpUsername, string smtpPassword)
//        {
//            _smtpServer = smtpServer;
//            _smtpRequiresAuthentication = smtpRequiresAuthentication;
//            _smtpUsername = smtpUsername;
//            _smtpPassword = smtpPassword;
//        }

//        public void Send(string senderEmail, string senderName, string mailTo, string subject, string body, Priority priority, string cc, string bcc, bool hasAttachment, string mailAttachments, bool deleteAttachmentAfterSend)
//        {
//            MailMessage msg = new MailMessage();
//            msg.From = new MailAddress(senderEmail, senderName);

//            if (!string.IsNullOrEmpty(mailTo))
//            {
//                string[] email = mailTo.Replace(",", ";").Split(Convert.ToChar(";"));
//                for (int n = 0; n <= email.Length - 1; n++)
//                {
//                    if (!string.IsNullOrEmpty(email[n]))
//                    {
//                        msg.To.Add(new MailAddress(email[n]));
//                    }
//                }
//            }

//            //Msg.To.Add(New MailAddress(MailTo))

//            if (!string.IsNullOrEmpty(cc))
//            {
//                string[] mailCc = cc.Replace(",", ";").Split(Convert.ToChar(";"));
//                for (int n = 0; n <= mailCc.Length - 1; n++)
//                {
//                    if (!string.IsNullOrEmpty(mailCc[n]))
//                    {
//                        msg.CC.Add(new MailAddress(mailCc[n]));
//                    }
//                }
//            }

//            if (!string.IsNullOrEmpty(bcc))
//            {
//                string[] mailBcc = bcc.Split(Convert.ToChar(","));
//                for (int n = 0; n <= mailBcc.Length - 1; n++)
//                {
//                    if (!string.IsNullOrEmpty(mailBcc[n]))
//                    {
//                        msg.Bcc.Add(new MailAddress(mailBcc[n]));
//                    }
//                }
//            }

//            msg.Subject = subject;
//            msg.Body = body;// Body.Replace(Constants.vbCrLf, "<BR>");
//            msg.Priority = (MailPriority)priority;
//            msg.IsBodyHtml = true;

//            if (hasAttachment)
//            {
//                string[] Path = mailAttachments.Split(Convert.ToChar(","));
//                for (int n = 0; n <= Path.Length - 1; n++)
//                {
//                    if (!string.IsNullOrEmpty(Path[n]))
//                    {
//                        FileInfo atcchPath = new FileInfo(Path[n]);
//                        if (atcchPath.Exists)
//                        {
//                            var attach = new Attachment(atcchPath.FullName);
//                            msg.Attachments.Add(attach);
//                        }
//                    }
//                }
//            }

//            SmtpClient emailClient = new SmtpClient();
//            if (_smtpRequiresAuthentication)
//            {
//                emailClient.UseDefaultCredentials = false;
//                emailClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
//            }
//            emailClient.Host = _smtpServer;

//            try
//            {
//                emailClient.Send(msg);

//                msg.Dispose();

//                if (hasAttachment & deleteAttachmentAfterSend)
//                {
//                    string[] path = mailAttachments.Split(Convert.ToChar(","));
//                    for (int n = 0; n <= path.Length - 1; n++)
//                    {
//                        if (!string.IsNullOrEmpty(path[n]))
//                        {
//                            FileInfo atcchPath = new FileInfo(path[n]);
//                            if (atcchPath.Exists)
//                            {
//                                atcchPath.Delete();
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public enum Priority
//        {
//            Normal = 0,
//            Low = 1,
//            High = 2
//        }
//    }
//}



