using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VB.Common.Entity;

namespace BALOTA.ViBaoHiem.Entity.ErrorCode
{
    [DataContract]
    public class ErrorMapping : ErrorMappingBase<ErrorMapping.ErrorCodes>
    {
        private static ErrorMapping _current;
        public static ErrorMapping Current
        {
            get { return _current ?? (_current = new ErrorMapping()); }
        }

        protected override void InitErrorMapping()
        {
            #region Security

            InnerHashtable[ErrorCodes.LoginInvalidEmail] = "Địa chỉ email không hợp lệ";
            InnerHashtable[ErrorCodes.LoginInvalidPassword] = "Mật khẩu không hợp lệ";
            InnerHashtable[ErrorCodes.LoginAccountHasBeenLocked] = "Tài khoản của Quý khách đã bị khóa";
            InnerHashtable[ErrorCodes.LoginAccountIsNotActived] = "Tài khoản của Quý khách chưa kích hoạt";
            InnerHashtable[ErrorCodes.LoginAccountActiveCodeError] = "Mã kích hoạt không hợp lệ";
            InnerHashtable[ErrorCodes.LoginAccountActiveAccountError] = "Tài khoản của Quý khách đang bị khóa nên không thể kích hoạt";
            InnerHashtable[ErrorCodes.LoginAccountAlreadyActived] = "Tài khoản của Quý khách đã được kích hoạt nên yêu cầu kích hoạt không hợp lệ";
            InnerHashtable[ErrorCodes.LoginAccountResetPasswordCodeError] = "Mã thay đổi mật khẩu không hợp lệ";

            InnerHashtable[ErrorCodes.UpdateUserInvalidUser] = "Thông tin người dùng không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserInvalidUsername] = "Tên đăng nhập không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserDuplicateUsername] = "Tên đăng nhập đã được đăng ký";
            InnerHashtable[ErrorCodes.UpdateUserInvalidPassword] = "Mật khẩu không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserInvalidConfirmPassword] = "Mật khẩu xác nhận lại không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserInvalidEmail] = "Địa chỉ email không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserDuplicateEmail] = "Địa chỉ email của Quý khách đã được đăng ký cho một tài khoản khác. Vui lòng kiểm tra lại thông tin đăng ký. Xin cảm ơn!";
            InnerHashtable[ErrorCodes.UpdateUserInvalidMobile] = "Số điện thoại không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateUserDuplicateMobile] = "Số điện thoại đã được sử dụng bởi một tài khoản khác";
            InnerHashtable[ErrorCodes.UpdateUserPasswordWeak] = "Mật khẩu phải có ít nhất 6 ký tự";

            #endregion
        }

        [DataContract]
        public enum ErrorCodes
        {
            #region General error

            [EnumMember]
            Success = ErrorCodeBase.Success,
            [EnumMember]
            UnknowError = ErrorCodeBase.UnknowError,
            [EnumMember]
            Exception = ErrorCodeBase.Exception,
            [EnumMember]
            BusinessError = ErrorCodeBase.BusinessError,
            [EnumMember]
            InvalidRequest = ErrorCodeBase.InvalidRequest,
            [EnumMember]
            TimeOutSession = ErrorCodeBase.TimeOutSession,
            [EnumMember]
            InvalidSiteId = ErrorCodeBase.InvalidSiteId,
            [EnumMember]
            InvalidBranchId = ErrorCodeBase.InvalidBranchId,

            #endregion

            #region Security

            LoginInvalidUsername = 100,
            LoginInvalidEmail = 101,
            LoginInvalidPassword = 102,
            LoginAccountHasBeenLocked = 103,
            LoginAccountIsNotActived = 104,
            LoginAccountActiveCodeError = 105,
            LoginAccountActiveAccountError = 106,
            LoginAccountAlreadyActived = 107,
            LoginAccountResetPasswordCodeError = 108,

            UpdateUserInvalidUser = 110,
            UpdateUserInvalidUsername = 111,
            UpdateUserDuplicateUsername = 112,
            UpdateUserInvalidPassword = 113,
            UpdateUserInvalidConfirmPassword = 114,
            UpdateUserInvalidEmail = 115,
            UpdateUserDuplicateEmail = 116,
            UpdateUserInvalidMobile = 117,
            UpdateUserDuplicateMobile = 119,
            UpdateUserPasswordWeak = 118,

            #endregion
        }
    }
}
