using System;
using System.Linq;
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
    public class CRMLeadCaptureMasterController : Controller
    {

        clsCRMLeadCaptureMasterBAL ezCRMLeadCaptureMasterBAL;
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

        private clsCRMLeadCaptureMasterVM FillDropDown(string CmpyCode)
        {
            clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM = new clsCRMLeadCaptureMasterVM();
            comFunction = new clsCommonFunction();

            CRMLeadCaptureMasterVM.ContactTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", " LookUpType='CRMContactTypeMaster'");
            CRMLeadCaptureMasterVM.MarriedStatusList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMMarriedStatusMaster'");
            CRMLeadCaptureMasterVM.ProfessionCodeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMProfessionCodeMaster'");
            CRMLeadCaptureMasterVM.DesignationTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMDesignationTypeMaster'");
            CRMLeadCaptureMasterVM.IncomeTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMIncomeMaster'");
            CRMLeadCaptureMasterVM.EmploymentTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMEmploymentTypeMaster'");
            CRMLeadCaptureMasterVM.AccountTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMAccountTypeListMaster'");
            CRMLeadCaptureMasterVM.LeadGenrationTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadGenrationTypeListMaster'");
            CRMLeadCaptureMasterVM.LeadSourceOutboundList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSourceOutboundListMaster'");
            CRMLeadCaptureMasterVM.LeadSourceInboundList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSourceInboundListMaster'");
            CRMLeadCaptureMasterVM.LeadSubSourceList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMLeadSubSourceListMaster'");
            CRMLeadCaptureMasterVM.SubStageList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, "order by Code", "LookUpType='CRMSubStageIDMaster'");

            return (CRMLeadCaptureMasterVM);
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

                clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM = FillDropDown(CmpyCode);
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                clsCRMLeadCaptureMaster CRMLeadCaptureMaster = new clsCRMLeadCaptureMaster();
                comFunction = new clsCommonFunction();
                CRMLeadCaptureMasterVM.CRMLeadCaptureMaster = CRMLeadCaptureMaster;
                CRMLeadCaptureMasterVM.CRMLeadCaptureMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                comFunction = new clsCommonFunction();
                CRMLeadCaptureMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (ControlsVM != null)
                    return View(CRMLeadCaptureMasterVM);
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
        public ActionResult Create(clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM)
        {
            try
            {

                object ezCRMLeadCaptureMaster = new clsCRMLeadCaptureMaster();
                ezCRMLeadCaptureMasterBAL = new clsCRMLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();

                /* Guid newGuid = Guid.NewGuid();
                 CRMLeadCaptureMasterVM.CRMLeadCaptureMaster.EmployeeID = newGuid.ToString();*/
                CRMLeadCaptureMasterVM.CRMLeadCaptureMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", CRMLeadCaptureMasterVM.userRequest.SectionId, CRMLeadCaptureMasterVM.userRequest.CompanyCode);
                ezCRMLeadCaptureMaster = comFunction.CopyProperties(CRMLeadCaptureMasterVM.CRMLeadCaptureMaster, ezCRMLeadCaptureMaster);
                ezCRMLeadCaptureMasterBAL.Insert(ezCRMLeadCaptureMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadCaptureMaster", new { CmpyCode = CRMLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMLeadCaptureMasterVM.userRequest.SectionId, userName = CRMLeadCaptureMasterVM.userRequest.UserName }) });
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
                clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                clsCRMLeadCaptureMaster CRMLeadCaptureMaster = new clsCRMLeadCaptureMaster();
                ezCRMLeadCaptureMasterBAL = new clsCRMLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMLeadCaptureMaster = ezCRMLeadCaptureMasterBAL.ReadSingle(Id);
                CRMLeadCaptureMasterVM.ControlsVM = ControlsVM;
                CRMLeadCaptureMasterVM.CRMLeadCaptureMaster = CRMLeadCaptureMaster;
                CRMLeadCaptureMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);

                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(CRMLeadCaptureMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM)
        {
            try
            {
                object CRMLeadCaptureMaster = new clsCRMLeadCaptureMaster();
                ezCRMLeadCaptureMasterBAL = new clsCRMLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMLeadCaptureMaster = comFunction.CopyProperties(CRMLeadCaptureMasterVM.CRMLeadCaptureMaster, CRMLeadCaptureMaster);
                //ezContactDatabaseMasterBAL.Update(ContactDatabaseMaster, "Code", ContactDatabaseMasterVM.ContactDatabaseMaster.Code);
                ezCRMLeadCaptureMasterBAL.Update(CRMLeadCaptureMaster, CRMLeadCaptureMasterVM.CRMLeadCaptureMaster.Code, "Code");
                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadCaptureMaster", new { CmpyCode = CRMLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMLeadCaptureMasterVM.userRequest.SectionId, userName = CRMLeadCaptureMasterVM.userRequest.UserName }) });
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
                clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM = FillDropDown(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMLeadCaptureMaster CRMLeadCaptureMaster = new clsCRMLeadCaptureMaster();
                ezCRMLeadCaptureMasterBAL = new clsCRMLeadCaptureMasterBAL();
                comFunction = new clsCommonFunction();
                CRMLeadCaptureMaster = ezCRMLeadCaptureMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "Code", CmpyCode);
                CRMLeadCaptureMasterVM.ControlsVM = ControlsVM;
                CRMLeadCaptureMasterVM.CRMLeadCaptureMaster = CRMLeadCaptureMaster;

                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(CRMLeadCaptureMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMLeadCaptureMasterVM CRMLeadCaptureMasterVM)
        {
            try
            {
                ezCRMLeadCaptureMasterBAL = new clsCRMLeadCaptureMasterBAL();
                ezCRMLeadCaptureMasterBAL.Delete(CRMLeadCaptureMasterVM.CRMLeadCaptureMaster.Code);

                return Json(new { redirectUrl = Url.Action("Index", "CRMLeadCaptureMaster", new { CmpyCode = CRMLeadCaptureMasterVM.userRequest.CompanyCode, Id = CRMLeadCaptureMasterVM.userRequest.SectionId, userName = CRMLeadCaptureMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
