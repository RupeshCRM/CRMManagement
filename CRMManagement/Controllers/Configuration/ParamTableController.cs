using CRMManagement.Models;
using CRM.Models.Configuration;
using CRM.BAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BAL;
using CRM.BAL.EzUsers;
using EZMasterSetup;
using CRM.Models.EzUsers;

namespace EzBusiness.Controllers.Configuration
{
    [SessionExpireFilter]
    public class ParamTableController : Controller
    {

        clsParamTableBAL ezParamTableBAL;
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
                ControlsVM = comFunction.GetData_In_CreateMode("uVw_UsersNewEntry", Id, userName, "SectionCode", CmpyCode);
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
        public ActionResult Create(clsParamTableVM ParamTableVM)
        {
            try
            {

                object ezParamTable = new clsParamTable();
                ezParamTableBAL = new clsParamTableBAL();
                comFunction = new clsCommonFunction();
                /*Guid newGuid = Guid.NewGuid();
                ParamTableVM.ParamTable.Code = newGuid.ToString();*/
                ezParamTable = comFunction.CopyProperties(ParamTableVM.ParamTable, ezParamTable);
                ezParamTableBAL.Insert(ezParamTable);
                return Json(new { redirectUrl = Url.Action("Index", "ParamTable", new { CmpyCode = ParamTableVM.userRequest.CompanyCode, Id = ParamTableVM.userRequest.SectionId, UserName = ParamTableVM.userRequest.UserName }) });
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
        public ActionResult Edit(clsParamTableVM ParamTableVM)
        {
            try
            {
                object ParamTable = new clsParamTable();
                ezParamTableBAL = new clsParamTableBAL();
                comFunction = new clsCommonFunction();
                ParamTable = comFunction.CopyProperties(ParamTableVM.ParamTable, ParamTable);
                //ezParamTableBAL.Update(ParamTable, "Code", ParamTableVM.ParamTable.Code);
                ezParamTableBAL.Update(ParamTable, ParamTableVM.ParamTable.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "ParamTable", new { CmpyCode = ParamTableVM.userRequest.CompanyCode, Id = ParamTableVM.userRequest.SectionId, UserName = ParamTableVM.userRequest.UserName }) });
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
        public ActionResult Delete(clsParamTableVM ParamTableVM)
        {
            try
            {
                ezParamTableBAL = new clsParamTableBAL();
                ezParamTableBAL.Delete(ParamTableVM.ParamTable.Code);
               
                return Json(new { redirectUrl = Url.Action("Index", "ParamTable", new { CmpyCode = ParamTableVM.userRequest.CompanyCode, Id = ParamTableVM.userRequest.SectionId, UserName = ParamTableVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
