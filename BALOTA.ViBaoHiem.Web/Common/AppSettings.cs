using VB.Common.CustomConfig;

namespace BALOTA.ViBaoHiem.CMS.Common
{
    public class AppSettings
    {

        /// <summary>
        /// Security level
        ///   0: Do not use OTP
        ///   1: Use OTP when Login only
        ///   2: Use OTP when Publish article or Edit published article
        /// </summary>
        public static int SecurityLevel
        {
            get
            {
                return CurrentConfig.GetAppSettingInInt32("SecurityLevel");
            }
        }
    }
}