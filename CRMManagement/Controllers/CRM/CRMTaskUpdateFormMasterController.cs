using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BAL.CRM;
using CRM.BAL.EzUsers;
using CRM.Models.CRM;
using CRM.Models.EzUsers;
using CRM.ModelsVM.CRM;
using CRMManagement.Models;
using EZMasterSetup;

namespace CRMManagement.Controllers.CRM
{
    [SessionExpireFilter]
    public class CRMTaskUpdateFormMasterController : Controller
    {
        clsCRMTaskUpdateFormMasterBAL ezCRMTaskUpdateFormMasterBAL;
        clsUserWorkflowRightsBAL ezUserWorkflowRightsBAL;
        clsUserRequestHandler UserRequestHandler;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsUserWorkflowRights userWorkflowRights;
        clsControlsVM ControlsVM;

        clsCommonFunction comFunction;


        private static void CopyProperties(object source, object destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source, null);
                    destinationProperty.SetValue(destination, value, null);
                }
            }
        }
        // GET: Users
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName, CmpyCode);
                ViewBag.SectionId = Id;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }
        // GET: EzSectionFieldMaster/Create
        public ActionResult Create(string CmpyCode, string Id, string userName)
        {
            try
            {

                clsCRMTaskUpdateFormMasterVM CRMTaskUpdateFormMasterVM = new clsCRMTaskUpdateFormMasterVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMTaskUpdateFormMaster CRMTaskUpdateFormMaster = new clsCRMTaskUpdateFormMaster();
                comFunction = new clsCommonFunction();
                CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster = CRMTaskUpdateFormMaster;
                CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (ControlsVM != null)
                    return View(ControlsVM);
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // POST: EzSectionFieldMaster/Create
        [HttpPost]
        public ActionResult Create(clsCRMTaskUpdateFormMasterVM CRMTaskUpdateFormMasterVM)
        {
            try
            {

                object ezCRMTaskUpdateFormMaster = new clsCRMTaskUpdateFormMaster();
                ezCRMTaskUpdateFormMasterBAL = new clsCRMTaskUpdateFormMasterBAL();
                comFunction = new clsCommonFunction();
                /*Guid newGuid = Guid.NewGuid();
                CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code = newGuid.ToString();*/
                CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMTaskUpdateFormMasterVM.userRequest.SectionId, CRMTaskUpdateFormMasterVM.userRequest.CompanyCode);

                ezCRMTaskUpdateFormMaster = comFunction.CopyProperties(CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster, ezCRMTaskUpdateFormMaster);
                ezCRMTaskUpdateFormMasterBAL.Insert(ezCRMTaskUpdateFormMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMTaskUpdateFormMaster", new { CmpyCode = CRMTaskUpdateFormMasterVM.userRequest.CompanyCode, Id = CRMTaskUpdateFormMasterVM.userRequest.SectionId, UserName = CRMTaskUpdateFormMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


        }
        // GET: EzSectionFieldMaster/Edit/5
        public ActionResult Edit(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMTaskUpdateFormMasterVM CRMTaskUpdateFormMasterVM)
        {
            try
            {
                object CRMTaskUpdateFormMaster = new clsCRMTaskUpdateFormMaster();
                ezCRMTaskUpdateFormMasterBAL = new clsCRMTaskUpdateFormMasterBAL();
                comFunction = new clsCommonFunction();
                CRMTaskUpdateFormMaster = comFunction.CopyProperties(CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster, CRMTaskUpdateFormMaster);
                //ezCRMTaskUpdateFormMasterBAL.Update(CRMTaskUpdateFormMaster, "Code", CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code);
                ezCRMTaskUpdateFormMasterBAL.Update(CRMTaskUpdateFormMaster, CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMTaskUpdateFormMaster", new { CmpyCode = CRMTaskUpdateFormMasterVM.userRequest.CompanyCode, Id = CRMTaskUpdateFormMasterVM.userRequest.SectionId, UserName = CRMTaskUpdateFormMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // GET: EzSectionFieldMaster/Delete/5
        public ActionResult Delete(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMTaskUpdateFormMasterVM CRMTaskUpdateFormMasterVM)
        {
            try
            {
                ezCRMTaskUpdateFormMasterBAL = new clsCRMTaskUpdateFormMasterBAL();
                ezCRMTaskUpdateFormMasterBAL.Delete(CRMTaskUpdateFormMasterVM.CRMTaskUpdateFormMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMTaskUpdateFormMaster", new { CmpyCode = CRMTaskUpdateFormMasterVM.userRequest.CompanyCode, Id = CRMTaskUpdateFormMasterVM.userRequest.SectionId, UserName = CRMTaskUpdateFormMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

