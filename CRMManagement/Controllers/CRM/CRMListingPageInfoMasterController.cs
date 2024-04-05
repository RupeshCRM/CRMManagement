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
using EZMasterSetup;

namespace CRMManagement.Controllers.CRM
{
    public class CRMListingPageInfoMasterController : Controller
    {
        clsCRMListingPageInfoMasterBAL ezCRMListingPageInfoMasterBAL;
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
        private clsCRMListingPageInfoMasterVM FillDropDown(string CmpyCode)
        {
            clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM = new clsCRMListingPageInfoMasterVM();
            comFunction = new clsCommonFunction();
            CRMListingPageInfoMasterVM.PropertyUseList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyUseListMaster'");
            CRMListingPageInfoMasterVM.PropertyTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPropertyTypeListMaster'");
            CRMListingPageInfoMasterVM.StreetList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", " LookUpType='CRMStreetListMaster'");
            CRMListingPageInfoMasterVM.CityList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCityListMaster'");
            CRMListingPageInfoMasterVM.StateList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMStateListMaster'");
            CRMListingPageInfoMasterVM.CountryList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMCountryListMaster'");
            CRMListingPageInfoMasterVM.AmenitiesList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMAmenitiesListMaster'");
            CRMListingPageInfoMasterVM.ListingTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMListingTypeListMaster'");
            CRMListingPageInfoMasterVM.RentalPriceTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMRentalPriceTypeListMaster'");
            CRMListingPageInfoMasterVM.PostToVariousPortalsList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMPostToVariousPortalsListMaster'");

            return (CRMListingPageInfoMasterVM);
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
                clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM = FillDropDown(CmpyCode);
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMListingPageInfoMaster CRMListingPageInfoMaster = new clsCRMListingPageInfoMaster();
                comFunction = new clsCommonFunction();
                CRMListingPageInfoMasterVM.CRMListingPageInfoMaster = CRMListingPageInfoMaster;
                CRMListingPageInfoMasterVM.CRMListingPageInfoMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                comFunction = new clsCommonFunction();
                CRMListingPageInfoMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (ControlsVM != null)
                    return View(CRMListingPageInfoMasterVM);
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
        public ActionResult Create(clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM)
        {
            try
            {

                object ezCRMListingPageInfoMaster = new clsCRMListingPageInfoMaster();
                ezCRMListingPageInfoMasterBAL = new clsCRMListingPageInfoMasterBAL();
                comFunction = new clsCommonFunction();
                /* Guid newGuid = Guid.NewGuid();
                 CRMListingPageInfoMasterVM.CRMListingPageInfoMaster.EmployeeID = newGuid.ToString();*/
                CRMListingPageInfoMasterVM.CRMListingPageInfoMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMListingPageInfoMasterVM.userRequest.SectionId, CRMListingPageInfoMasterVM.userRequest.CompanyCode);

                ezCRMListingPageInfoMaster = comFunction.CopyProperties(CRMListingPageInfoMasterVM.CRMListingPageInfoMaster, ezCRMListingPageInfoMaster);
                ezCRMListingPageInfoMasterBAL.Insert(ezCRMListingPageInfoMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMListingPageInfoMaster", new { CmpyCode = CRMListingPageInfoMasterVM.userRequest.CompanyCode, Id = CRMListingPageInfoMasterVM.userRequest.SectionId, userName = CRMListingPageInfoMasterVM.userRequest.UserName }) });
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
                clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                clsCRMListingPageInfoMaster CRMListingPageInfoMaster = new clsCRMListingPageInfoMaster();
                ezCRMListingPageInfoMasterBAL = new clsCRMListingPageInfoMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingPageInfoMaster = ezCRMListingPageInfoMasterBAL.ReadSingle(Id);
                CRMListingPageInfoMasterVM.ControlsVM = ControlsVM;
                CRMListingPageInfoMasterVM.CRMListingPageInfoMaster = CRMListingPageInfoMaster;
                CRMListingPageInfoMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);

                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(CRMListingPageInfoMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM)
        {
            try
            {
                object CRMListingPageInfoMaster = new clsCRMListingPageInfoMaster();
                ezCRMListingPageInfoMasterBAL = new clsCRMListingPageInfoMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingPageInfoMaster = comFunction.CopyProperties(CRMListingPageInfoMasterVM.CRMListingPageInfoMaster, CRMListingPageInfoMaster);
                //ezContactDatabaseMasterBAL.Update(ContactDatabaseMaster, "Code", ContactDatabaseMasterVM.ContactDatabaseMaster.Code);
                ezCRMListingPageInfoMasterBAL.Update(CRMListingPageInfoMaster, CRMListingPageInfoMasterVM.CRMListingPageInfoMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMListingPageInfoMaster", new { CmpyCode = CRMListingPageInfoMasterVM.userRequest.CompanyCode, Id = CRMListingPageInfoMasterVM.userRequest.SectionId, userName = CRMListingPageInfoMasterVM.userRequest.UserName }) });
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
                clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMListingPageInfoMaster CRMListingPageInfoMaster = new clsCRMListingPageInfoMaster();
                ezCRMListingPageInfoMasterBAL = new clsCRMListingPageInfoMasterBAL();
                comFunction = new clsCommonFunction();
                CRMListingPageInfoMaster = ezCRMListingPageInfoMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                CRMListingPageInfoMasterVM.ControlsVM = ControlsVM;
                CRMListingPageInfoMasterVM.CRMListingPageInfoMaster = CRMListingPageInfoMaster;

                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(CRMListingPageInfoMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMListingPageInfoMasterVM CRMListingPageInfoMasterVM)
        {
            try
            {
                ezCRMListingPageInfoMasterBAL = new clsCRMListingPageInfoMasterBAL();
                ezCRMListingPageInfoMasterBAL.Delete(CRMListingPageInfoMasterVM.CRMListingPageInfoMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMListingPageInfoMaster", new { CmpyCode = CRMListingPageInfoMasterVM.userRequest.CompanyCode, Id = CRMListingPageInfoMasterVM.userRequest.SectionId, userName = CRMListingPageInfoMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
