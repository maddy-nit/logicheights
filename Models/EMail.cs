using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net.Mail;

namespace Logic_Heights.Models
{
    public class EMail
    {

        private string FromAddress;
        private string strToAddress;
        private string strSmtpClient;
        private string UserID;
        private string Password;
        private string ReplyTo;
        private string SMTPPort;
        private Boolean bEnableSSL;

        private void InitMail()
        {
            FromAddress = System.Configuration.ConfigurationManager.AppSettings.Get("FromAddress");
            strToAddress = System.Configuration.ConfigurationManager.AppSettings.Get("ToAddress");
            //strSmtpClient = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpClient");
            strSmtpClient = "smtp.gmail.com";
            UserID = System.Configuration.ConfigurationManager.AppSettings.Get("UserID");
            Password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
            ReplyTo = System.Configuration.ConfigurationManager.AppSettings.Get("ReplyTo");
            SMTPPort = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPort");
            if (System.Configuration.ConfigurationManager.AppSettings.Get("EnableSSL").ToUpper() == "YES")
            {
                bEnableSSL = true;
            }
            else
            {
                bEnableSSL = false;
            }
        }

        public bool SendMail(ContactModel Model)
        {
               //string toAddress = "support@logicheights.com";
              
                InitMail();

                dynamic MailMessage = new MailMessage();
                MailMessage.From = new MailAddress(FromAddress);
                MailMessage.To.Add(strToAddress);
                MailMessage.Subject = "Support";
                MailMessage.IsBodyHtml = true;
                MailMessage.Body = "<html> <head> </head>" +
                    " <body style= \" font-size:12px; font-family: Arial; color:orange\">" +
                    Model.Message + "<br><br><br><br>" + "From: <br><font color=\"#2c3e50\">" + Model.Name + "<br>" + Model.Email + "<br>" + Model.Phone +
                    "</font></body></html>";

                MailMessage.ReplyTo = new MailAddress(FromAddress);

                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.Host = strSmtpClient;
                SmtpClient.EnableSsl = bEnableSSL;
                SmtpClient.Port = Convert.ToInt32(SMTPPort);
                SmtpClient.Credentials = new System.Net.NetworkCredential(UserID, Password);
                try
                {
                    SmtpClient.Send(MailMessage);
                    return true;
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    for (int i = 0; i <= ex.InnerExceptions.Length; i++)
                    {
                        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                        if ((status == SmtpStatusCode.MailboxBusy) | (status == SmtpStatusCode.MailboxUnavailable))
                        {
                            System.Threading.Thread.Sleep(5000);
                            SmtpClient.Send(MailMessage);
                        }
                    }
                }
                return false;
            
        }
    }
}