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
using static System.Collections.Specialized.BitVector32;

namespace CRMManagement.Controllers.CRM
{
    [SessionExpireFilter]
    public class CRMContactInformationMasterController : Controller
    {
        clsCRMContactInformationMasterBAL ezCRMContactInformationMasterBAL;
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
                comFunction = new clsCommonFunction();
                createEditUserRequestHandler=new clsCreateEditUserRequestHandler();
                ControlsVM=createEditUserRequestHandler.CreateHandler(Id, userName);
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
        public ActionResult Create(clsCRMContactInformationMasterVM CRMContactInformationMasterVM)
        {
            try
            {

                object ezCRMContactInformationMaster = new clsCRMContactInformationMaster();
                ezCRMContactInformationMasterBAL = new clsCRMContactInformationMasterBAL();
                comFunction = new clsCommonFunction();
                Guid newGuid = Guid.NewGuid();
                CRMContactInformationMasterVM.CRMContactInformationMaster.Code = newGuid.ToString();
                ezCRMContactInformationMaster = comFunction.CopyProperties(CRMContactInformationMasterVM.CRMContactInformationMaster, ezCRMContactInformationMaster);
                ezCRMContactInformationMasterBAL.Insert(ezCRMContactInformationMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMContactInformationMaster", new { CmpyCode = CRMContactInformationMasterVM.userRequest.CompanyCode, Id = CRMContactInformationMasterVM.userRequest.SectionId, UserName = CRMContactInformationMasterVM.userRequest.UserName }) });
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
        public ActionResult Edit(clsCRMContactInformationMasterVM CRMContactInformationMasterVM)
        {
            try
            {
                object CRMContactInformationMaster = new clsCRMContactInformationMaster();
                ezCRMContactInformationMasterBAL = new clsCRMContactInformationMasterBAL();
                comFunction = new clsCommonFunction();
                CRMContactInformationMaster = comFunction.CopyProperties(CRMContactInformationMasterVM.CRMContactInformationMaster, CRMContactInformationMaster);
                //ezCRMContactInformationMasterBAL.Update(CRMContactInformationMaster, "Code", CRMContactInformationMasterVM.CRMContactInformationMaster.Code);
                ezCRMContactInformationMasterBAL.Update(CRMContactInformationMaster, CRMContactInformationMasterVM.CRMContactInformationMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMContactInformationMaster", new { CmpyCode = CRMContactInformationMasterVM.userRequest.CompanyCode, Id = CRMContactInformationMasterVM.userRequest.SectionId, UserName = CRMContactInformationMasterVM.userRequest.UserName }) });
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
        public ActionResult Delete(clsCRMContactInformationMasterVM CRMContactInformationMasterVM)
        {
            try
            {
                ezCRMContactInformationMasterBAL = new clsCRMContactInformationMasterBAL();
                ezCRMContactInformationMasterBAL.Delete(CRMContactInformationMasterVM.CRMContactInformationMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMContactInformationMaster", new { CmpyCode = CRMContactInformationMasterVM.userRequest.CompanyCode, Id = CRMContactInformationMasterVM.userRequest.SectionId, UserName = CRMContactInformationMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
