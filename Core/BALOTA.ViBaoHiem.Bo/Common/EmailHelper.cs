using BALOTA.ViBaoHiem.Bo.Common;
using BALOTA.ViBaoHiem.Entity;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using VB.Common.Converter;
using VB.Common.CustomConfig;
using VB.Common.Log;

namespace BALOTA.ViBaoHiem.Bo
{
    public class EmailHelper
    {
        private static EmailHelper _instance;
        public static EmailHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmailHelper();
                    _instance.SmtpHost = CurrentConfig.GetAppSetting("SmtpHost");
                    _instance.SmtpPort = Functions.GetInt(CurrentConfig.GetAppSetting("SmtpPort"));
                    _instance.SmtpUsername = CurrentConfig.GetAppSetting("SmtpUsername");
                    _instance.SmtpPassword = CurrentConfig.GetAppSetting("SmtpPassword");
                    _instance.SmtpEnableSsl = Functions.GetBoolean(CurrentConfig.GetAppSetting("SmtpEnableSsl"));
                    _instance.SmtpDefaultFromMail = CurrentConfig.GetAppSetting("SmtpDefaultFromMail");

                    var basePath = CurrentConfig.GetAppSetting("MailTemplate_BasePath");
                    if (!basePath.EndsWith("\\")) basePath = basePath + "\\";
                    _instance.MailTemplate_BasePath = basePath;

                    _instance.MailTemplate_ActiveAccount = basePath + CurrentConfig.GetAppSetting("MailTemplate_ActiveAccount");
                    _instance.MailTemplate_RecoverAccount = basePath + CurrentConfig.GetAppSetting("MailTemplate_RecoverAccount");
                    _instance.MailTemplate_ConfirmBuyOrder = basePath + CurrentConfig.GetAppSetting("MailTemplate_ConfirmBuyOrder");
                    _instance.MailTemplate_OrderCancelOrOutOfStock = basePath + CurrentConfig.GetAppSetting("MailTemplate_OrderCancelOrOutOfStock");

                    var host = CurrentConfig.GetAppSetting("WEB_HOST");
                    if (host.EndsWith("/")) host = host.Remove(host.Length - 1);
                    _instance.ActiveLink = host + CurrentConfig.GetAppSetting("PublicLinkFormat_AccountActive");
                    _instance.RecoverLink = host + CurrentConfig.GetAppSetting("PublicLinkFormat_RecoverAccount");
                    _instance.ConfirmBuyOrderLink = host + CurrentConfig.GetAppSetting("PublicLinkFormat_ConfirmBuyOrder");
                    _instance.OrderDetailLink = host + CurrentConfig.GetAppSetting("PublicLinkFormat_OrderDetail");

                    _instance.WebTitle = CurrentConfig.GetAppSetting("WEB_TITLE");
                }
                return _instance;
            }
        }

        #region SMTP Mailer
        private string SmtpHost { get; set; }
        private int SmtpPort { get; set; }
        private string SmtpUsername { get; set; }
        private string SmtpPassword { get; set; }
        private bool SmtpEnableSsl { get; set; }
        #endregion

        #region Mail config
        private string SmtpDefaultFromMail { get; set; }
        private string MailTemplate_BasePath { get; set; }
        private string MailTemplate_ActiveAccount { get; set; }
        private string MailTemplate_RecoverAccount { get; set; }
        private string MailTemplate_ConfirmBuyOrder { get; set; }
        private string MailTemplate_OrderCancelOrOutOfStock { get; set; }
        #endregion

        #region For public link
        private string WebTitle { get; set; }
        private string ActiveLink { get; set; }
        private string RecoverLink { get; set; }
        private string ConfirmBuyOrderLink { get; set; }
        private string OrderDetailLink { get; set; }
        #endregion

        private bool SendMailByGoogle(string from, string to, string cc, string bcc, string subject, string content, ref string errorMsg)
        {
            string str2;
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                errorMsg = "From or to email address is null or empty.";
                return false;
            }
            MailMessage message = new MailMessage
            {
                From = new MailAddress(from)
            };
            cc = to;
            string[] strArray = cc.Split(new char[] { ';' });
            int num = 0;
            foreach (string str in strArray)
            {
                str2 = str.Trim();
                if (str2 != string.Empty)
                {
                    if (num == 0)
                    {
                        message.To.Add(str2);
                    }
                    else
                    {
                        message.CC.Add(str2);
                    }
                    num++;
                }
            }
            string[] strArray2 = bcc.Split(new char[] { ';' });
            foreach (string str in strArray2)
            {
                str2 = str.Trim();
                if (str2 != string.Empty)
                {
                    message.Bcc.Add(str2);
                }
            }
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;
            SmtpClient client2 = new SmtpClient(SmtpHost, SmtpPort)
            {
                Credentials = new NetworkCredential(SmtpUsername, SmtpPassword),
                EnableSsl = SmtpEnableSsl,
                Timeout = 0x4e20,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            SmtpClient client = client2;
            try
            {
                client.Send(message);
                errorMsg = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Logger.WriteLog(Logger.LogType.Error, ex.ToString());
                return false;
            }
        }
        private bool SendMailByGoogle(string to, string subject, string content)
        {
            string str2;
            string errorMsg;
            if (string.IsNullOrEmpty(to))
            {
                errorMsg = "From or to email address is null or empty.";
                return false;
            }
            MailMessage message = new MailMessage
            {
                From = new MailAddress(SmtpDefaultFromMail)
            };
            message.To.Add(to);
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;
            SmtpClient client2 = new SmtpClient(SmtpHost, SmtpPort)
            {
                Credentials = new NetworkCredential(SmtpUsername, SmtpPassword),
                EnableSsl = SmtpEnableSsl,
                Timeout = 0x4e20,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            SmtpClient client = client2;
            try
            {
                client.Send(message);
                errorMsg = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Logger.WriteLog(Logger.LogType.Error, ex.ToString());
                return false;
            }
        }

        public bool SendRecoverPasswordEmail(string customerEmail, string fullName, string resetCode)
        {
            var subject = (string.IsNullOrEmpty(_instance.WebTitle) ? "[ " : _instance.WebTitle + " ] ") + "Yêu cầu thay đổi mật khẩu đăng nhập";
            var resetLink = string.Format(RecoverLink, resetCode);
            var sentResult = false;

            var mailContent = "";
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(MailTemplate_RecoverAccount);

            htmlDoc.DocumentNode.SelectSingleNode("//strong[@id='EmailRecoverAccount_Username']").InnerHtml = fullName;
            htmlDoc.DocumentNode.SelectSingleNode("//a[@id='EmailRecoverAccount_ResetLink']").SetAttributeValue("href", resetLink);
            htmlDoc.DocumentNode.SelectSingleNode("//strong[@id='EmailRecoverAccount_RecoverLinkText']").InnerHtml = resetLink;
            mailContent = htmlDoc.DocumentNode.OuterHtml;

            if (!string.IsNullOrEmpty(mailContent))
            {
                var threadProcess = new Thread(delegate ()
                {
                    sentResult = SendMailByGoogle(customerEmail, subject, mailContent);
                });
                threadProcess.Start();
            }

            return sentResult;
        }
    }
}
