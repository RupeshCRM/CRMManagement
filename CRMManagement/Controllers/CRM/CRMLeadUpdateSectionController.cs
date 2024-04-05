using CRM.BAL.CRM;
using CRM.BAL.EzUsers;
using CRM.Models.CRM;
using CRM.Models.EzUsers;
using CRM.ModelsVM.CRM;
using CRMManagement.Models;
using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMManagement.Controllers.CRM
{
    [SessionExpireFilter]
    public class CRMLeadUpdateSectionController : Controller
    {
        clsCRMLeadUpdateSectionBAL ezCRMLeadUpdateSectionBAL;
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
                clsCRMLeadUpdateSectionVM CRMLeadUpdateSectionVM = new clsCRMLeadUpdateSectionVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMLeadUpdateSection CRMLeadUpdateSection = new clsCRMLeadUpdateSection();
                comFunction = new clsCommonFunction();
                CRMLeadUpdateSectionVM.CRMLeadUpdateSection = CRMLeadUpdateSection;
                CRMLeadUpdateSectionVM.CRMLeadUpdateSection.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                //ControlsVM = comFunction.GetData_In_CreateMode("uVw_UsersNewEntry", Id, userName, "SectionCode", CmpyCode);
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
        public ActionResult Create(clsCRMLeadUpdateSectionVM CRMLeadUpdateSectionVM)
        {
            try
            {

                object ezCRMLeadUpdateSection = new clsCRMLeadUpdateSection();
                ezCRMLeadUpdateSectionBAL = new clsCRMLeadUpdateSectionBAL();
                comFunction = new clsCommonFunction();
                /*Guid newGuid = Guid.NewGuid();
                CRMTaskUpdateFormMasterVM.CRMLeadUpdateSection.Code = newGuid.ToString();*/
                CRMLeadUpdateSectionVM.CRMLeadUpdateSection.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMLeadUpdateSectionVM.userRequest.SectionId, CRMLeadUpdateSectionVM.userRequest.CompanyCode);

                ezCRMLeadUpdateSection = comFunction.CopyProperties(CRMLeadUpdateSectionVM.CRMLeadUpdateSection, ezCRMLeadUpdateSection);
                ezCRMLeadUpdateSectionBAL.Insert(ezCRMLeadUpdateSection);
                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadUpdateSection", new { CmpyCode = CRMLeadUpdateSectionVM.userRequest.CompanyCode, Id = CRMLeadUpdateSectionVM.userRequest.SectionId, UserName = CRMLeadUpdateSectionVM.userRequest.UserName }) });
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
        public ActionResult Edit(clsCRMLeadUpdateSectionVM CRMLeadUpdateSectionVM)
        {
            try
            {
                object CRMLeadUpdateSection = new clsCRMLeadUpdateSection();
                ezCRMLeadUpdateSectionBAL = new clsCRMLeadUpdateSectionBAL();
                comFunction = new clsCommonFunction();
                CRMLeadUpdateSection = comFunction.CopyProperties(CRMLeadUpdateSectionVM.CRMLeadUpdateSection, CRMLeadUpdateSection);
                //ezCRMLeadUpdateSectionBAL.Update(CRMLeadUpdateSection, "Code", CRMLeadUpdateSectionVM.CRMLeadUpdateSection.Code);
                ezCRMLeadUpdateSectionBAL.Update(CRMLeadUpdateSection, CRMLeadUpdateSectionVM.CRMLeadUpdateSection.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadUpdateSection", new { CmpyCode = CRMLeadUpdateSectionVM.userRequest.CompanyCode, Id = CRMLeadUpdateSectionVM.userRequest.SectionId, UserName = CRMLeadUpdateSectionVM.userRequest.UserName }) });
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
        public ActionResult Delete(clsCRMLeadUpdateSectionVM CRMLeadUpdateSectionVM)
        {
            try
            {
                ezCRMLeadUpdateSectionBAL = new clsCRMLeadUpdateSectionBAL();
                ezCRMLeadUpdateSectionBAL.Delete(CRMLeadUpdateSectionVM.CRMLeadUpdateSection.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadUpdateSection", new { CmpyCode = CRMLeadUpdateSectionVM.userRequest.CompanyCode, Id = CRMLeadUpdateSectionVM.userRequest.SectionId, UserName = CRMLeadUpdateSectionVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}

