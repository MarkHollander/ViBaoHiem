using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.CMS.Common;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Entity.ErrorCode;
using Newtonsoft.Json;
using VB.Common.Log;

namespace BALOTA.ViBaoHiem.Web_MVC.Controllers.User.MemberManagement
{
    public class MemberListController : Controller
    {
        // GET: MemberList
        private UserEntity curUser
        {
            get
            {
                try
                {
                    return HttpContext.Session["CurrentUser"] as UserEntity;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, ex.ToString());
                    return null;
                }
            }
        }

        public ActionResult MemberListView()
        {
            if (curUser != null)
            {
                // 0: lay tat ca cac unLocked Member
                List<MemberListEntity> listOfMember = CurrentUser.IsSupperAdmin ? UserBo.MemberList_GetAllAgency(0) : UserBo.MemberList_GetAllAgency(curUser.UserId, 0);
                return View("~/Views/User/MemberManagement/MemberManagementView.cshtml", listOfMember);
            }
            else return RedirectToAction("Index","UserLogin");
        }

        [HttpPost]
        public PartialViewResult MemberList_ConfirmDeletePopup(long inputId)
        {
            MemberEntity inputMember = UserBo.Member_GetMemberByMemberId(inputId);
            return PartialView("~/Views/User/MemberManagement/MemberList_ConfirmDeletePopup.cshtml", inputMember);
        }

        [HttpPost]
        public PartialViewResult MemberList_CreateAgencyPopup()
        {            
            return PartialView("~/Views/User/MemberManagement/MemberList_CreateAgencyPopup.cshtml");
        }

        public PartialViewResult MemberList_UpdateAgencyPopup(long inputId)
        {
            MemberEntity inputMember = UserBo.Member_GetMemberByMemberId(inputId);
            return PartialView("~/Views/User/MemberManagement/MemberList_UpdateAgencyPopup.cshtml", inputMember);
        }

        public PartialViewResult MemberList_AddBalancePopup(long inputId)
        {
            ViewData["Agency"] = UserBo.MemberList_GetAgencyByMemberId(inputId);
            return PartialView("~/Views/User/MemberManagement/MemberList_AddBalancePopup.cshtml");
        }

        public PartialViewResult MemberList_SubtractBalancePopup(long inputId)
        {
            MemberListEntity inputMember = UserBo.MemberList_GetAgencyByMemberId(inputId);
            return PartialView("~/Views/User/MemberManagement/MemberList_SubtractBalancePopup.cshtml", inputMember);
        }

        [HttpPost]
        public JsonResult MemberList_CreateNewAgency(MemberEntity newAgency)
        {
            
            {
                
                ErrorMapping.ErrorCodes code = UserBo.CreateAgency(newAgency, ref memberId);
                switch(code)
                {
                    case ErrorMapping.ErrorCodes.Success:
                        responseText = "Tạo đại lý thành công"; break;
                    case ErrorMapping.ErrorCodes.UpdateUserInvalidUsername:
                        responseText = "Username không được để trống"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.UpdateUserInvalidPassword:
                        responseText = "Password không được để trống"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.UpdateUserInvalidEmail:
                        responseText = "Email không được để trống"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.UpdateUserInvalidUser:
                        responseText = "Thông tin truyền vào không phù hợp"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.UpdateUserDuplicateUsername:
                        responseText = "Username đã tồn tại"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail:
                        responseText = "Email đã sử dụng"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.BusinessError:
                        responseText = "Lỗi nghiệp vụ"; memberId = -1; break;
                    default:
                        responseText = "Lỗi không xác định"; memberId = -1; break;
                };
                return new JsonResult
                {
                    UserBo.CreateMember(newAgency, ref memberId);
                    var data = new
                    {
            }
            else
            {
        }

        [HttpPost]
        public JsonResult MemberList_UpdateAgency(MemberEntity updateAgency)
        {
            long memberId = -1;            
            string responseText = "";
            try
            {
                ErrorMapping.ErrorCodes code = UserBo.UpdateAgency(updateAgency);
                switch (code)
                {
                    case ErrorMapping.ErrorCodes.Success:
                        responseText = "Sửa đại lý thành công"; memberId = updateAgency.MemberId; break;                    
                    case ErrorMapping.ErrorCodes.UpdateUserInvalidUser:
                        responseText = "Thông tin truyền vào không phù hợp"; memberId = -1; break;                    
                    case ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail:
                        responseText = "Email đã sử dụng"; memberId = -1; break;
                    case ErrorMapping.ErrorCodes.BusinessError:
                        responseText = "Lỗi nghiệp vụ"; memberId = -1; break;
                    default:
                        responseText = "Lỗi không xác định"; memberId = -1; break;
                };
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        memberid = memberId
                        ,
                        result = responseText
                    }
                };
            }
            catch (Exception ex)
            {
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        memberid = -2
                        ,
                        result = ex.Message
                    }
                };
            }
        }


        public ActionResult MemberList_LockMember(long inputId)
        {
            bool result = UserBo.LockMember(inputId);
            return RedirectToAction("MemberListView", curUser);
        }

        //load danh sach Dai ly 
        public JsonResult MemberListLoadData()
        {
            UserEntity currentUser = (UserEntity)HttpContext.Session["CurrentUserEntity"];
            List<MemberListEntity> listOfMember = UserBo.MemberList_GetAllAgency(-1);
            return Json(listOfMember, JsonRequestBehavior.AllowGet);
        }
    }
}