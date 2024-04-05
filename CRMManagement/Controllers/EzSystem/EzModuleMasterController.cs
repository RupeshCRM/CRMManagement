using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BAL;
using CRM.Models;
using CRMManagement.Models;
using EZMasterSetup;
using Microsoft.Ajax.Utilities;
using static System.Collections.Specialized.BitVector32;
namespace EzBusiness.Controllers
{
    [SessionExpireFilter]
    public class EzModuleMasterController : Controller
    {
        clsControlsVM ControlsVM;
        clsEzModuleMasterBAL ezModuleMasterBAL;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;

        private bool RecordManipulation()
        {
            bool blnRecord = true; 
            try
            {

            }
            catch (Exception)
            {

                
            }
            return (blnRecord);
        }

        // GET: EzModuleMaster
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {
            createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
            ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName);
            ViewBag.SectionId = Id;
            return View(ControlsVM);
        }

        // GET: EzModuleMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EzModuleMaster/Create
        public ActionResult Create(string Id,string userName)
        {
            try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
            }
            catch (Exception)
            {
                throw;
            }
            return View(ControlsVM);
        }

        // POST: EzModuleMaster/Create
        [HttpPost]
        public ActionResult Create(clsEzModuleMasterVM EzModuleMasterVM)
        {
            try
            {
                
                clsEzModuleMaster ezModuleMaster=new clsEzModuleMaster();
                Guid newGuid = Guid.NewGuid();
                ezModuleMaster.ModuleCode = newGuid.ToString();
                ezModuleMaster.Description = EzModuleMasterVM.ezModuleMaster.Description;
                ezModuleMaster.isEnabled = EzModuleMasterVM.ezModuleMaster.isEnabled;
                ezModuleMasterBAL = new clsEzModuleMasterBAL();
                ezModuleMasterBAL.Insert(ezModuleMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzModuleMaster", new { Id = EzModuleMasterVM.userRequest.SectionId , UserName= EzModuleMasterVM.userRequest.UserName }) });
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EzModuleMaster/Edit/5
        public ActionResult Edit(string SectionId,string Id, string userName)
        {
            try
            {
               
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezModuleMasterBAL = new clsEzModuleMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezModuleMasterBAL.GetAllData_DataTable("ModuleCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable,ControlsVM);
                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception)
            {
                throw;
            }
            return View(ControlsVM);
        }

        // POST: EzModuleMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsEzModuleMasterVM EzModuleMasterVM)
        {
            try
            {
                
                clsEzModuleMaster ezModuleMaster = new clsEzModuleMaster();
                ezModuleMaster.ModuleCode = EzModuleMasterVM.ezModuleMaster.ModuleCode;
                ezModuleMaster.Description = EzModuleMasterVM.ezModuleMaster.Description;
                ezModuleMaster.isEnabled = EzModuleMasterVM.ezModuleMaster.isEnabled;
                ezModuleMasterBAL = new clsEzModuleMasterBAL();
                ezModuleMasterBAL.Update(ezModuleMaster, "ModuleCode", EzModuleMasterVM.ezModuleMaster.ModuleCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzModuleMaster", new { Id = EzModuleMasterVM.userRequest.SectionId, UserName = EzModuleMasterVM.userRequest.UserName }) });

            }
            catch
            {
                return View();
            }
        }

        // GET: EzModuleMaster/Delete/5
        public ActionResult Delete(string SectionId, string Id, string userName)
        {
            try
            {
               
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezModuleMasterBAL = new clsEzModuleMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezModuleMasterBAL.GetAllData_DataTable("ModuleCode", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception)
            {
                throw;
            }
            return View(ControlsVM);
        }

        // POST: EzModuleMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsEzModuleMasterVM EzModuleMasterVM)
        {
            try
            {
                
                ezModuleMasterBAL = new clsEzModuleMasterBAL();
                ezModuleMasterBAL.Delete(EzModuleMasterVM.ezModuleMaster.ModuleCode);
                return Json(new { redirectUrl = Url.Action("Index", "EzModuleMaster", new { Id = EzModuleMasterVM.userRequest.SectionId, UserName = EzModuleMasterVM.userRequest.UserName }) });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Close(string SectionId, string userName)
        {
            try
            {
                return Json(new { redirectUrl = Url.Action("Index", "EzModuleMaster", new { Id = SectionId, UserName = userName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult Clear(string SectionId, string userName)
        {
            try
            {
                return Json(new { redirectUrl = Url.Action("Create", "EzModuleMaster", new { Id = SectionId, UserName = userName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
