using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.CMS.Common;
using BALOTA.ViBaoHiem.Entity;

namespace BALOTA.ViBaoHiem.Web_MVC.Controllers.Member
{
    public class MemberInformationController : Controller
    {
        // GET: MemberInformation

        //User
        public ActionResult MemberInformation(long inputId)
        {
            //lay thong tin cua Member
            MemberListEntity member = UserBo.MemberList_GetAgencyByMemberId(inputId);            
            ViewData["member"] = member?? new MemberListEntity();
            return View("~/Views/User/MemberManagement/MemberInformation_Update.cshtml");
        }

        //lay thong tin cac cong tac vien
        [HttpPost]
        public JsonResult CollaboratorListLoadData(long inputId)
        {            
            List<MemberListEntity> listOfMember = MemberBo.MemberList_GetAllCollaborator(inputId, -1);
            return Json(listOfMember, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public PartialViewResult MemberList_ConfirmDeletePopup(long inputId)
        {
            MemberEntity inputMember = UserBo.Member_GetMemberByMemberId(inputId);
            return PartialView("~/Views/Member/CollaboratorList_ConfirmDeletePopup.cshtml", inputMember);
        }

        // GET: MemberInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberInformation/Create
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

        // GET: MemberInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberInformation/Edit/5
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

        // GET: MemberInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberInformation/Delete/5
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
