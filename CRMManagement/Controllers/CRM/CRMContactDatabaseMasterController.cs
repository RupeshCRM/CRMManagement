using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BAL.CRM;
using CRM.BAL.EzUsers;
using CRM.Models;
using CRM.Models.CRM;
using CRM.Models.EzUsers;
using CRM.ModelsVM.CRM;
using CRMManagement.Models;
using EZMasterSetup;

namespace CRMManagement.Controllers.CRM
{
    [SessionExpireFilter]
    public class CRMContactDatabaseMasterController : Controller
    {

        clsCRMContactDatabaseMasterBAL ezCRMContactDatabaseMasterBAL;
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
        private clsCRMContactDatabaseMasterVM FillDropDown(string CmpyCode)
        {
            clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM = new clsCRMContactDatabaseMasterVM();
            comFunction = new clsCommonFunction();

            CRMContactDatabaseMasterVM.ContactTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code", " LookUpType='CRMContactTypeMaster'");
            CRMContactDatabaseMasterVM.MarriedStatusList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMMarriedStatusMaster'");
            CRMContactDatabaseMasterVM.ProfessionCodeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMProfessionCodeMaster'");
            CRMContactDatabaseMasterVM.DesignationTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMDesignationTypeMaster'");
            CRMContactDatabaseMasterVM.IncomeTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMIncomeMaster'");
            CRMContactDatabaseMasterVM.EmploymentTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMEmploymentTypeMaster'");
            CRMContactDatabaseMasterVM.ContactSubTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", " LookUpType='CRMContactSubTypeListMaster'");
            CRMContactDatabaseMasterVM.AccountTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMAccountTypeListMaster'");
            CRMContactDatabaseMasterVM.PropertyUseList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyUseListMaster'");
            CRMContactDatabaseMasterVM.PropertyTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyTypeListMaster'");
            CRMContactDatabaseMasterVM.StreetList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", " LookUpType='CRMStreetListMaster'");
            CRMContactDatabaseMasterVM.CityList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCityListMaster'");
            CRMContactDatabaseMasterVM.StateList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMStateListMaster'");
            CRMContactDatabaseMasterVM.CountryList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCountryListMaster'");

            return (CRMContactDatabaseMasterVM);
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
                clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM = FillDropDown(CmpyCode);
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMContactDatabaseMaster CRMContactDatabaseMaster = new clsCRMContactDatabaseMaster();
                comFunction = new clsCommonFunction();
                CRMContactDatabaseMasterVM.CRMContactDatabaseMaster = CRMContactDatabaseMaster;
                CRMContactDatabaseMasterVM.CRMContactDatabaseMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                comFunction = new clsCommonFunction();
                CRMContactDatabaseMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode); 
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (ControlsVM != null)
                    return View(CRMContactDatabaseMasterVM);
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
        public ActionResult Create(clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM)
        {
            try
            {

                object ezCRMContactDatabaseMaster = new clsCRMContactDatabaseMaster();
                ezCRMContactDatabaseMasterBAL = new clsCRMContactDatabaseMasterBAL();
                comFunction = new clsCommonFunction();

                /* Guid newGuid = Guid.NewGuid();
                 CRMContactDatabaseMasterVM.CRMContactDatabaseMaster.EmployeeID = newGuid.ToString();*/
                CRMContactDatabaseMasterVM.CRMContactDatabaseMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMContactDatabaseMasterVM.userRequest.SectionId, CRMContactDatabaseMasterVM.userRequest.CompanyCode);

                ezCRMContactDatabaseMaster = comFunction.CopyProperties(CRMContactDatabaseMasterVM.CRMContactDatabaseMaster, ezCRMContactDatabaseMaster);
                ezCRMContactDatabaseMasterBAL.Insert(ezCRMContactDatabaseMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMContactDatabaseMaster", new { CmpyCode = CRMContactDatabaseMasterVM.userRequest.CompanyCode, Id = CRMContactDatabaseMasterVM.userRequest.SectionId, userName = CRMContactDatabaseMasterVM.userRequest.UserName }) });
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
                clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                clsCRMContactDatabaseMaster CRMContactDatabaseMaster = new clsCRMContactDatabaseMaster();
                ezCRMContactDatabaseMasterBAL = new clsCRMContactDatabaseMasterBAL();
                comFunction = new clsCommonFunction();
                CRMContactDatabaseMaster = ezCRMContactDatabaseMasterBAL.ReadSingle(Id);
                CRMContactDatabaseMasterVM.ControlsVM = ControlsVM;
                CRMContactDatabaseMasterVM.CRMContactDatabaseMaster = CRMContactDatabaseMaster;
                CRMContactDatabaseMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(CRMContactDatabaseMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM)
        {
            try
            {
                object CRMContactDatabaseMaster = new clsCRMContactDatabaseMaster();
                ezCRMContactDatabaseMasterBAL = new clsCRMContactDatabaseMasterBAL();
                comFunction = new clsCommonFunction();
                CRMContactDatabaseMaster = comFunction.CopyProperties(CRMContactDatabaseMasterVM.CRMContactDatabaseMaster, CRMContactDatabaseMaster);
                //ezContactDatabaseMasterBAL.Update(ContactDatabaseMaster, "Code", ContactDatabaseMasterVM.ContactDatabaseMaster.Code);
                ezCRMContactDatabaseMasterBAL.Update(CRMContactDatabaseMaster, CRMContactDatabaseMasterVM.CRMContactDatabaseMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMContactDatabaseMaster", new { CmpyCode = CRMContactDatabaseMasterVM.userRequest.CompanyCode, Id = CRMContactDatabaseMasterVM.userRequest.SectionId, userName = CRMContactDatabaseMasterVM.userRequest.UserName }) });
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
                clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMContactDatabaseMaster CRMContactDatabaseMaster = new clsCRMContactDatabaseMaster();
                ezCRMContactDatabaseMasterBAL = new clsCRMContactDatabaseMasterBAL();
                comFunction = new clsCommonFunction();
                CRMContactDatabaseMaster = ezCRMContactDatabaseMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                CRMContactDatabaseMasterVM.ControlsVM = ControlsVM;
                CRMContactDatabaseMasterVM.CRMContactDatabaseMaster = CRMContactDatabaseMaster;
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(CRMContactDatabaseMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMContactDatabaseMasterVM CRMContactDatabaseMasterVM)
        {
            try
            {
                ezCRMContactDatabaseMasterBAL = new clsCRMContactDatabaseMasterBAL();
                ezCRMContactDatabaseMasterBAL.Delete(CRMContactDatabaseMasterVM.CRMContactDatabaseMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMContactDatabaseMaster", new { CmpyCode = CRMContactDatabaseMasterVM.userRequest.CompanyCode, Id = CRMContactDatabaseMasterVM.userRequest.SectionId, userName = CRMContactDatabaseMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
