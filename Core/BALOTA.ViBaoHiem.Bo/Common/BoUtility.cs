using BALOTA.ViBaoHiem.Entity;
using System;
using System.Drawing;
using System.IO;
using VB.Common.Security;

namespace BALOTA.ViBaoHiem.Bo.Common
{
    public class BoUtility
    {
        public enum EnumActiveCodeType : int
        {
            ForActiveMember = 1,
            ForRecoverPassword = 2
        }
        public enum EnumConfirmOrderCodeType : int
        {
            AcceptToBuy = 1,
            RejectBuy = 2
        }
        private const int TextLengthForActiveCode = 16;
        public static string GetActiveCodeForMember(EnumActiveCodeType type, string activeCode, long memberId)
        {
            return activeCode + "^" + memberId + "^" + ((int)type).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decryptActiveInfo"></param>
        /// <returns>
        /// 0:ActiveCode; 1:MemberId; 3:Type
        /// </returns>
        public static string[] GetActiveInfoForMember(string decryptActiveInfo)
        {
            return decryptActiveInfo.Split('^');
        }
        public static string GetConfirmCodeForOrder(EnumConfirmOrderCodeType type, long orderId)
        {
            return orderId + "^" + ((int)type).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decryptConfirmInfo"></param>
        /// <returns>
        /// 0:OrderId; 1:Type
        /// </returns>
        public static string[] GetConfirmCodeForOrder(string decryptConfirmInfo)
        {
            return decryptConfirmInfo.Split('^');
        }
    }
}
