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

namespace EzBusiness.Controllers
{
    [SessionExpireFilter]
    public class EzSectionMasterController : Controller
    {
        clsControlsVM ControlsVM;
        clsSectionMasterBAL sectionMasterBAL;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        // GET: EzSectionMaster
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {
           
            createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
            ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName);
            ViewBag.SectionId = Id;
            return View(ControlsVM);
        }

        // GET: EzSectionMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EzSectionMaster/Create
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
            catch (Exception)
            {
                return View();
            }
        }

        // POST: EzSectionMaster/Create
        [HttpPost]
        public ActionResult Create(clsEzSectionMasterVM EzSectionMasterVM)
        {
            try
            {
                clsEzSectionMaster ezSectionMaster = new clsEzSectionMaster();
                sectionMasterBAL = new clsSectionMasterBAL();
                ezSectionMaster.SectionCode = EzSectionMasterVM.ezSectionMaster.SectionCode;
                ezSectionMaster.Description = EzSectionMasterVM.ezSectionMaster.Description;
                ezSectionMaster.WorkflowCode = EzSectionMasterVM.ezSectionMaster.WorkflowCode;
                ezSectionMaster.isApplicableForTable = EzSectionMasterVM.ezSectionMaster.isApplicableForTable;
                sectionMasterBAL.Insert(ezSectionMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionMaster", new { Id = EzSectionMasterVM.userRequest.SectionId, UserName = EzSectionMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzSectionMaster/Edit/5
        public ActionResult Edit(string SectionId, string Id, string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                sectionMasterBAL = new clsSectionMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = sectionMasterBAL.GetAllData_DataTable("SectionCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
                ViewBag.SectionId = SectionId;
                ViewBag.oprType = "Edit";
            }
            catch (Exception)
            {
                //throw;
            }
            return View(ControlsVM);
        }

        // POST: EzSectionMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsEzSectionMasterVM EzSectionMasterVM)
        {
            try
            {
                clsEzSectionMaster ezSectionMaster = new clsEzSectionMaster();
                sectionMasterBAL = new clsSectionMasterBAL();
                ezSectionMaster.SectionCode = EzSectionMasterVM.ezSectionMaster.SectionCode;
                ezSectionMaster.Description = EzSectionMasterVM.ezSectionMaster.Description;
                ezSectionMaster.WorkflowCode = EzSectionMasterVM.ezSectionMaster.WorkflowCode;
                ezSectionMaster.isApplicableForTable = EzSectionMasterVM.ezSectionMaster.isApplicableForTable;
                sectionMasterBAL.Update(ezSectionMaster, EzSectionMasterVM.ezSectionMaster.SectionCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionMaster", new { Id = EzSectionMasterVM.userRequest.SectionId, UserName = EzSectionMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzSectionMaster/Delete/5
        public ActionResult Delete(string SectionId, string Id, string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                sectionMasterBAL = new clsSectionMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = sectionMasterBAL.GetAllData_DataTable("SectionCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
                ViewBag.SectionId = SectionId;
                ViewBag.oprType = "Delete";
                return View(ControlsVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
           
        }

        // POST: EzSectionMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsEzSectionMasterVM EzSectionMasterVM)
        {
            try
            {
                clsEzSectionMaster ezSectionMaster = new clsEzSectionMaster();
                sectionMasterBAL = new clsSectionMasterBAL();
                sectionMasterBAL.Delete(EzSectionMasterVM.ezSectionMaster.SectionCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionMaster", new { Id = EzSectionMasterVM.userRequest.SectionId, UserName = EzSectionMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
