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
    public class CRMListingLeadCaptureMasterController : Controller
    {
        clsCRMListingLeadCaptureMasterBAL ezCRMListingLeadCaptureMasterBAL;
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

        private clsCRMListingLeadCaptureMasterVM FillDropDown(string CmpyCode)
        {
            clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM = new clsCRMListingLeadCaptureMasterVM();
            comFunction = new clsCommonFunction();

            CRMListingLeadCaptureMasterVM.ContactTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", " LookUpType='CRMContactTypeMaster'");
            CRMListingLeadCaptureMasterVM.MarriedStatusList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMMarriedStatusMaster'");
            CRMListingLeadCaptureMasterVM.ProfessionCodeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMProfessionCodeMaster'");
            CRMListingLeadCaptureMasterVM.DesignationTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMDesignationTypeMaster'");
            CRMListingLeadCaptureMasterVM.IncomeTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMIncomeMaster'");
            CRMListingLeadCaptureMasterVM.EmploymentTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMEmploymentTypeMaster'");
            CRMListingLeadCaptureMasterVM.AccountTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMAccountTypeListMaster'");
            CRMListingLeadCaptureMasterVM.LeadGenrationTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadGenrationTypeListMaster'");
            CRMListingLeadCaptureMasterVM.LeadSourceOutboundList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSourceOutboundListMaster'");
            CRMListingLeadCaptureMasterVM.LeadSourceInboundList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSourceInboundListMaster'");
            CRMListingLeadCaptureMasterVM.LeadSubSourceList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSubSourceListMaster'");
            CRMListingLeadCaptureMasterVM.LeadStatusList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadStatusListMaster'");
            CRMListingLeadCaptureMasterVM.PropertyNameList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyNameListMaster'");
            CRMListingLeadCaptureMasterVM.PropertyUseList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyUseListMaster'");
            CRMListingLeadCaptureMasterVM.PropertyTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyTypeListMaster'");
            CRMListingLeadCaptureMasterVM.StreetList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMStreetListMaster'");
            CRMListingLeadCaptureMasterVM.CityList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCityListMaster'");
            CRMListingLeadCaptureMasterVM.StateList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMStateListMaster'");
            CRMListingLeadCaptureMasterVM.CountryList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCountryListMaster'");
            CRMListingLeadCaptureMasterVM.ListingTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMListingTypeListMaster'");
            CRMListingLeadCaptureMasterVM.RentalPriceTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMRentalPriceTypeListMaster'");

            return (CRMListingLeadCaptureMasterVM);
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
                clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM = FillDropDown(CmpyCode);
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMListingLeadCaptureMaster CRMListingLeadCaptureMaster = new clsCRMListingLeadCaptureMaster();
                comFunction = new clsCommonFunction();
                CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster = CRMListingLeadCaptureMaster;
                CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                comFunction = new clsCommonFunction();
                CRMListingLeadCaptureMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode); 
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (ControlsVM != null)
                    return View(CRMListingLeadCaptureMasterVM);
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
        public ActionResult Create(clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM)
        {
            try
            {

                object ezCRMListingLeadCaptureMaster = new clsCRMListingLeadCaptureMaster();
                ezCRMListingLeadCaptureMasterBAL = new clsCRMListingLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();

                /* Guid newGuid = Guid.NewGuid();
                 CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster.EmployeeID = newGuid.ToString();*/
                CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMListingLeadCaptureMasterVM.userRequest.SectionId, CRMListingLeadCaptureMasterVM.userRequest.CompanyCode);
                ezCRMListingLeadCaptureMaster = comFunction.CopyProperties(CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster, ezCRMListingLeadCaptureMaster);
                ezCRMListingLeadCaptureMasterBAL.Insert(ezCRMListingLeadCaptureMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMListingLeadCaptureMaster", new { CmpyCode = CRMListingLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMListingLeadCaptureMasterVM.userRequest.SectionId, userName = CRMListingLeadCaptureMasterVM.userRequest.UserName }) });
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
                clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                clsCRMListingLeadCaptureMaster CRMListingLeadCaptureMaster = new clsCRMListingLeadCaptureMaster();
                ezCRMListingLeadCaptureMasterBAL = new clsCRMListingLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingLeadCaptureMaster = ezCRMListingLeadCaptureMasterBAL.ReadSingle(Id);
                CRMListingLeadCaptureMasterVM.ControlsVM = ControlsVM;
                CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster = CRMListingLeadCaptureMaster;
                CRMListingLeadCaptureMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);

                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(CRMListingLeadCaptureMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM)
        {
            try
            {
                object CRMListingLeadCaptureMaster = new clsCRMListingLeadCaptureMaster();
                ezCRMListingLeadCaptureMasterBAL = new clsCRMListingLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingLeadCaptureMaster = comFunction.CopyProperties(CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster, CRMListingLeadCaptureMaster);
                //ezContactDatabaseMasterBAL.Update(ContactDatabaseMaster, "Code", ContactDatabaseMasterVM.ContactDatabaseMaster.Code);
                ezCRMListingLeadCaptureMasterBAL.Update(CRMListingLeadCaptureMaster, CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMListingLeadCaptureMaster", new { CmpyCode = CRMListingLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMListingLeadCaptureMasterVM.userRequest.SectionId, userName = CRMListingLeadCaptureMasterVM.userRequest.UserName }) });
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
                clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMListingLeadCaptureMaster CRMListingLeadCaptureMaster = new clsCRMListingLeadCaptureMaster();
                ezCRMListingLeadCaptureMasterBAL = new clsCRMListingLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingLeadCaptureMaster = ezCRMListingLeadCaptureMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                CRMListingLeadCaptureMasterVM.ControlsVM = ControlsVM;
                CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster = CRMListingLeadCaptureMaster;


                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(CRMListingLeadCaptureMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMListingLeadCaptureMasterVM CRMListingLeadCaptureMasterVM)
        {
            try
            {
                ezCRMListingLeadCaptureMasterBAL = new clsCRMListingLeadCaptureMasterBAL();
                ezCRMListingLeadCaptureMasterBAL.Delete(CRMListingLeadCaptureMasterVM.CRMListingLeadCaptureMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMListingLeadCaptureMaster", new { CmpyCode = CRMListingLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMListingLeadCaptureMasterVM.userRequest.SectionId, userName = CRMListingLeadCaptureMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
