using CRM.BAL;
using CRM.Models;
using CRMManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using EZMasterSetup;

namespace EzBusiness.Controllers.EzSystem
{
    [SessionExpireFilter]
    public class EzWorkflowEditDisplayMasterController : Controller
    {
        clsEzWorkflowEditDisplayMasterBAL ezWorkflowEditDisplayMasterBAL;
        clsUserRequestHandler UserRequestHandler;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsControlsVM ControlsVM;
        clsUserRequest userRequest;
        clsCommonFunction ComFuntions;
        // GET: EzSectionFieldMaster
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {

            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName);
                ViewBag.SectionId = Id;
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
            return View(ControlsVM);
        }

        // GET: EzSectionFieldMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EzSectionFieldMaster/Create
        public ActionResult Create(string Id, string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName);
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
        public ActionResult Create(clsEzWorkflowEditDisplayMasterVM ezWorkflowEditDisplayMasterVM)
        {
            try
            {

                object ezSectionFieldMaster = new clsEzWorkflowEditDisplayMaster();
                ezWorkflowEditDisplayMasterBAL = new clsEzWorkflowEditDisplayMasterBAL();
                ComFuntions = new clsCommonFunction();
                Guid newGuid = Guid.NewGuid();
                ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster.SectionEditCode = newGuid.ToString();
                ezSectionFieldMaster = ComFuntions.CopyProperties(ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster, ezSectionFieldMaster);
                ezWorkflowEditDisplayMasterBAL.Insert(ezSectionFieldMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzWorkflowEditDisplayMaster", new { Id = ezWorkflowEditDisplayMasterVM.userRequest.SectionId, UserName = ezWorkflowEditDisplayMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzSectionFieldMaster/Edit/5
        public ActionResult Edit(string SectionId, string Id, string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezWorkflowEditDisplayMasterBAL = new clsEzWorkflowEditDisplayMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezWorkflowEditDisplayMasterBAL.GetAllData_DataTable("SectionEditCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
               ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsEzWorkflowEditDisplayMasterVM ezWorkflowEditDisplayMasterVM)
        {
            try
            {
                object ezWorkflowEditDisplayMaster = new clsEzWorkflowEditDisplayMaster();
                ezWorkflowEditDisplayMasterBAL = new clsEzWorkflowEditDisplayMasterBAL();
                ComFuntions = new clsCommonFunction();
                ezWorkflowEditDisplayMaster = ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster;
                ezWorkflowEditDisplayMaster = ComFuntions.CopyProperties(ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster, ezWorkflowEditDisplayMaster);
                ezWorkflowEditDisplayMasterBAL.Delete(ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster.SectionEditCode);
                ezWorkflowEditDisplayMasterBAL.Insert(ezWorkflowEditDisplayMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzWorkflowEditDisplayMaster", new { Id = ezWorkflowEditDisplayMasterVM.userRequest.SectionId, UserName = ezWorkflowEditDisplayMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzSectionFieldMaster/Delete/5
        public ActionResult Delete(string SectionId, string Id, string userName)
        {
            try
            {
                clsEzWorkflowEditDisplayMaster ezSectionFieldMaster = new clsEzWorkflowEditDisplayMaster();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezWorkflowEditDisplayMasterBAL = new clsEzWorkflowEditDisplayMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezWorkflowEditDisplayMasterBAL.GetAllData_DataTable("SectionEditCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
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
        public ActionResult Delete(clsEzWorkflowEditDisplayMasterVM ezWorkflowEditDisplayMasterVM)
        {
            try
            {
                ezWorkflowEditDisplayMasterBAL = new clsEzWorkflowEditDisplayMasterBAL();
                ezWorkflowEditDisplayMasterBAL.Delete(ezWorkflowEditDisplayMasterVM.ezWorkflowEditDisplayMaster.SectionEditCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzWorkflowEditDisplayMaster", new { Id = ezWorkflowEditDisplayMasterVM.userRequest.SectionId, UserName = ezWorkflowEditDisplayMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
