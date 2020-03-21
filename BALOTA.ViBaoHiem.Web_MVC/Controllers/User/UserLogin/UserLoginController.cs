using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BALOTA.ViBaoHiem.CMS.Common;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Bo;
using System.Web.Security;
using BALOTA.ViBaoHiem.Entity.ErrorCode;

namespace BALOTA.ViBaoHiem.Web_MVC.Controllers.User.UserLogin
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View("~/Views/User/UserLogin/UserLogin_ViewPage.cshtml");
        }

        [HttpPost]
        public ActionResult UserLogin(UserEntity user)
        {
            var username = user.Username;
            var password = user.Password;
            UserEntity userInfo = null;

            var errorCode = SecurityBo.Login(username, password, ref userInfo);
            if (errorCode == Entity.ErrorCode.ErrorMapping.ErrorCodes.Success && userInfo != null)
            {
                FormsAuthentication.Initialize();
                FormsAuthentication.SetAuthCookie(userInfo.Username, false, "~/Views/User/MemberManagement/MemberManagementView.cshtml");
                HttpContext.Session["CurrentUser"] = userInfo;
                CurrentUser.Username = username;                
                ViewBag.ShowName = username;
                return RedirectToAction("MemberListView", "MemberList");
            }
            else
            {
                ViewBag.Message = CmsMessage.ShowMessage(CmsMessage.MessageType.Danger, ErrorMapping.Current[errorCode]);
                return View("~/Views/User/UserLogin/UserLogin_ViewPage.cshtml");
            }            
        }

        // GET: UserLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserLogin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserLogin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
