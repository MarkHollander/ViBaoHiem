using System.Web.UI.WebControls;

namespace BALOTA.ViBaoHiem.CMS.Common
{
    public class CmsMessage
    {
        public enum MessageType
        {
            Success = 0,
            Info = 1,
            Warning = 2,
            Danger = 3
        }
        public static string ShowMessage(MessageType type, string message)
        {
            const string messageFormat =
                "<div class=\"alert alert-{0} alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><strong>{1}</strong></div>";
            switch (type)
            {
                case MessageType.Success:
                    return string.Format(messageFormat, "success", message);
                case MessageType.Warning:
                    return string.Format(messageFormat, "warning", message);
                case MessageType.Danger:
                    return string.Format(messageFormat, "danger", message);
                default:
                    return string.Format(messageFormat, "info", message);
            }
        }
        public static string ShowModalAlertMessage(string title, string message, string urlToRedirect = "")
        {
            return string.Format("<script>ShowErrorModalPopup('{0}', '{1}', '{2}')</script>", title.Replace("'", "''"), message.Replace("'", "''"), urlToRedirect.Replace("'", "''"));
        }
        public static string ShowModalAlertMessageWithCallbackButton(string title, string message, string callbackButtonLabel, string callbackFunction = "", string cancelCallbackFunction = "")
        {
            return string.Format("<script>ShowModalAlertMessageWithCallbackButton('{0}', '{1}', '{2}', '{3}', '{4}')</script>", title.Replace("'", "''"), message.Replace("'", "''"), callbackButtonLabel.Replace("'", "''"), callbackFunction.Replace("'", "''"), cancelCallbackFunction.Replace("'", "''"));
        }
        public static void ShowMessage(MessageType type, string message, ref Literal ltrMessage)
        {
            const string messageFormat =
                "<div class=\"alert alert-{0} alert-dismissable\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><strong>{1}</strong></div>";
            switch (type)
            {
                case MessageType.Success:
                    ltrMessage.Text = string.Format(messageFormat, "success", message);
                    break;
                case MessageType.Warning:
                    ltrMessage.Text = string.Format(messageFormat, "warning", message);
                    break;
                case MessageType.Danger:
                    ltrMessage.Text = string.Format(messageFormat, "danger", message);
                    break;
                default:
                    ltrMessage.Text = string.Format(messageFormat, "info", message);
                    break;
            }
        }
    }
}