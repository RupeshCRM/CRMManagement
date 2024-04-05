using CRM.BAL;
using CRM.BAL.EzSystem;
using CRM.Models;
using CRM.Models.EzSystem;
using CRMManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EZMasterSetup;

namespace EzBusiness.Controllers.EzSystem
{
    [SessionExpireFilter]
    public class EzCommonMasterController : Controller
    {

        clsControlsVM ControlsVM;

        clsCommonMasterBAL ezCommonMasterBAL;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsCommonFunction comFunction;

        private string GetTableName(string SectionId)
        {
            clsEzWorkflowMasterBAL ezWorkflowMasterBAL = new clsEzWorkflowMasterBAL();
            clsEzWorkflowMaster ezWorkflowMaster = ezWorkflowMasterBAL.ReadSingle(SectionId);
            return (ezWorkflowMaster.disTableName);
        }
        // GET: EzCommonMaster
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {
            createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
            string strLookUpType = GetTableName(Id);
            ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName, CmpyCode,true, strLookUpType);
            ViewBag.SectionId = Id;
            return View(ControlsVM);
        }

        // GET: EzCommonMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EzCommonMaster/Create
        public ActionResult Create(string CmpyCode, string Id, string userName)
        {
            try
            {

                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                comFunction = new clsCommonFunction();
                ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.SectionId = Id;
                ViewBag.oprType = "Create";
                foreach (var item in ControlsVM.controls)
                {
                    if (item.FieldName == "Code")
                    {
                        item.value = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                        break;
                        //ControlsVM.controls.up
                    }
                }
                if (ControlsVM != null)
                    return View(ControlsVM);
                else
                    return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: EzCommonMaster/Create
        [HttpPost]
        public ActionResult Create(clsCommonMasterVM ezCommonMasterVM)
        {
            try
            {
                comFunction = new clsCommonFunction();
                object ezCommonMaster = new clsCommonMaster();
                ezCommonMasterBAL = new clsCommonMasterBAL();
                comFunction = new clsCommonFunction();
                if (ezCommonMasterVM.commonMaster.Code == "" || ezCommonMasterVM.commonMaster.Code is null)
                {
                    Guid newGuid = Guid.NewGuid();
                    ezCommonMasterVM.commonMaster.Code = newGuid.ToString();
                }
                else
                {
                    ezCommonMasterVM.commonMaster.Code=comFunction.GF_Get_AutoCode_ParamTable("SAVE", ezCommonMasterVM.userRequest.SectionId, ezCommonMasterVM.userRequest.CompanyCode);
                }
              

                ezCommonMasterVM.commonMaster.LookUpType= GetTableName(ezCommonMasterVM.userRequest.SectionId);// ezCommonMasterVM.userRequest.SectionId;
                ezCommonMaster = comFunction.CopyProperties(ezCommonMasterVM.commonMaster, ezCommonMaster);
                ezCommonMasterBAL.Insert(ezCommonMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzCommonMaster", new { CmpyCode = ezCommonMasterVM.userRequest.CompanyCode, Id = ezCommonMasterVM.userRequest.SectionId, userName = ezCommonMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzCommonMaster/Edit/5
        public ActionResult Edit(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                object ezCommonMaster = new clsCommonMaster();
                ezCommonMasterBAL = new clsCommonMasterBAL();
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode_CommonMaster(SectionId, Id, userName, "Code", CmpyCode);
                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(ControlsVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: EzCommonMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCommonMasterVM ezCommonMasterVM)
        {
            try
            {
                object ezCommonMaster = new clsCommonMaster();
                ezCommonMasterBAL = new clsCommonMasterBAL();
                comFunction = new clsCommonFunction();
                ezCommonMasterVM.commonMaster.LookUpType = GetTableName(ezCommonMasterVM.userRequest.SectionId);
                ezCommonMaster = comFunction.CopyProperties(ezCommonMasterVM.commonMaster, ezCommonMaster);
                ezCommonMasterBAL.Update(ezCommonMaster, "Code", ezCommonMasterVM.commonMaster.Code);
                return Json(new { redirectUrl = Url.Action("Index", "EzCommonMaster", new { CmpyCode = ezCommonMasterVM.userRequest.CompanyCode, Id = ezCommonMasterVM.userRequest.SectionId, userName = ezCommonMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzCommonMaster/Delete/5
        public ActionResult Delete(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                object ezCommonMaster = new clsCommonMaster();
                ezCommonMasterBAL = new clsCommonMasterBAL();
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode_CommonMaster(SectionId, Id, userName, "Code", CmpyCode);
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }

        // POST: EzCommonMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCommonMasterVM ezCommonMasterVM)
        {
            try
            {
                ezCommonMasterBAL = new clsCommonMasterBAL();
                ezCommonMasterBAL.Delete(ezCommonMasterVM.commonMaster.Code);
                return Json(new { redirectUrl = Url.Action("Index", "EzCommonMaster", new { CmpyCode = ezCommonMasterVM.userRequest.CompanyCode, Id = ezCommonMasterVM.userRequest.SectionId, userName = ezCommonMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
