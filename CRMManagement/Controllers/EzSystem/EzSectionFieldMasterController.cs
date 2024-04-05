using CRM.BAL;
using CRM.Models;
using CRMManagement.Models;
using Newtonsoft.Json;
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
    public class EzSectionFieldMasterController : Controller
    {
        clsEzSectionFieldMasterBAL ezSectionFieldMasterBAL;
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
        public ActionResult Create(clsEzSectionFieldMasterVM ezSectionFieldMasterVM)
        {
            try
            {
               
                object ezSectionFieldMaster = new clsEzSectionFieldMaster();
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                ComFuntions = new clsCommonFunction();
                Guid newGuid = Guid.NewGuid();
                ezSectionFieldMasterVM.ezSectionFieldMaster.SectionFieldCode = newGuid.ToString();
                ezSectionFieldMaster = ComFuntions.CopyProperties(ezSectionFieldMasterVM.ezSectionFieldMaster, ezSectionFieldMaster);
                ezSectionFieldMasterBAL.Insert(ezSectionFieldMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionFieldMaster", new { Id = ezSectionFieldMasterVM.userRequest.SectionId, UserName = ezSectionFieldMasterVM.userRequest.UserName }) });
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
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezSectionFieldMasterBAL.GetAllData_DataTable("SectionFieldCode", Id.ToString());
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
        public ActionResult Edit(clsEzSectionFieldMasterVM ezSectionFieldMasterVM)
        {
            try
            {
                object ezSectionFieldMaster = new clsEzSectionFieldMaster();
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                ComFuntions = new clsCommonFunction();
                ezSectionFieldMaster = ezSectionFieldMasterVM.ezSectionFieldMaster;
                ezSectionFieldMaster = ComFuntions.CopyProperties(ezSectionFieldMasterVM.ezSectionFieldMaster, ezSectionFieldMaster);
                ezSectionFieldMasterBAL.Delete(ezSectionFieldMasterVM.ezSectionFieldMaster.SectionFieldCode);
                ezSectionFieldMasterBAL.Insert(ezSectionFieldMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionFieldMaster", new { Id = ezSectionFieldMasterVM.userRequest.SectionId, UserName = ezSectionFieldMasterVM.userRequest.UserName }) });
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
                clsEzSectionFieldMaster ezSectionFieldMaster = new clsEzSectionFieldMaster();
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezSectionFieldMasterBAL.GetAllData_DataTable("SectionFieldCode", Id.ToString());
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
        public ActionResult Delete(clsEzSectionFieldMasterVM ezSectionFieldMasterVM)
        {
            try
            {
                ezSectionFieldMasterBAL = new clsEzSectionFieldMasterBAL();
                ezSectionFieldMasterBAL.Delete(ezSectionFieldMasterVM.ezSectionFieldMaster.SectionFieldCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzSectionFieldMaster", new { Id = ezSectionFieldMasterVM.userRequest.SectionId, UserName = ezSectionFieldMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
