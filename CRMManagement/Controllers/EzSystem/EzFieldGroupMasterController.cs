using CRM.BAL;
using CRM.Models;
using CRMManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using EZMasterSetup;

namespace EzBusiness.Controllers.EzSystem
{
    [SessionExpireFilter]
    public class EzFieldGroupMasterController : Controller
    {


        clsControlsVM ControlsVM;

        clsEzFieldGroupMasterBAL ezFieldGroupMasterBAL;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsCommonFunction ComFuntions;
        // GET: EzSectionMaster
        public ActionResult Index(string CmpyCode, string Id, string userName)
        {

            createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
            ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName);
            ViewBag.SectionId = Id;
            FillAllControllers();
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
                ViewBag.SectionId = Id;
                ViewBag.oprType = "Create";
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
        public ActionResult Create(clsEzFieldGroupMasterVM ezFieldGroupMasterVM)
        {
            try
            {

                object EzFieldGroupMaster = new clsEzFieldGroupMaster();
                ezFieldGroupMasterBAL = new clsEzFieldGroupMasterBAL();
                ComFuntions = new clsCommonFunction();
                Guid newGuid = Guid.NewGuid();
                ezFieldGroupMasterVM.ezFieldGroupMaster.Code = newGuid.ToString();
                EzFieldGroupMaster = ComFuntions.CopyProperties(ezFieldGroupMasterVM.ezFieldGroupMaster, EzFieldGroupMaster);
                ezFieldGroupMasterBAL.Insert(EzFieldGroupMaster);
                return Json(new { redirectUrl = Url.Action("Index", "EzFieldGroupMaster", new { Id = ezFieldGroupMasterVM.userRequest.SectionId, UserName = ezFieldGroupMasterVM.userRequest.UserName }) });
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
                ezFieldGroupMasterBAL = new clsEzFieldGroupMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezFieldGroupMasterBAL.GetAllData_DataTable("Code", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception)
            {
                //throw;
            }
            return View(ControlsVM);
        }

        // POST: EzSectionMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsEzFieldGroupMasterVM ezFieldGroupMasterVM)
        {
            try
            {
                object EzFieldGroupMaster = new clsEzFieldGroupMaster();
                ezFieldGroupMasterBAL = new clsEzFieldGroupMasterBAL();
                ComFuntions = new clsCommonFunction();
                EzFieldGroupMaster = ComFuntions.CopyProperties(ezFieldGroupMasterVM.ezFieldGroupMaster, EzFieldGroupMaster);
                ezFieldGroupMasterBAL.Update(EzFieldGroupMaster, "Code", ezFieldGroupMasterVM.ezFieldGroupMaster.Code);
                return Json(new { redirectUrl = Url.Action("Index", "EzFieldGroupMaster", new { Id = ezFieldGroupMasterVM.userRequest.SectionId, UserName = ezFieldGroupMasterVM.userRequest.UserName }) });
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

                clsEzFieldGroupMaster EzFieldGroupMaster = new clsEzFieldGroupMaster();
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ezFieldGroupMasterBAL = new clsEzFieldGroupMasterBAL();
                ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);
                DataTable dataTable = ezFieldGroupMasterBAL.GetAllData_DataTable("Code", Id.ToString());
                ControlsVM = createEditUserRequestHandler.FillValuesInRespectiveControls(dataTable, ControlsVM);
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(ControlsVM);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: EzSectionMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsEzFieldGroupMasterVM ezFieldGroupMasterVM)
        {
            try
            {

                ezFieldGroupMasterBAL = new clsEzFieldGroupMasterBAL();
                ezFieldGroupMasterBAL.Delete(ezFieldGroupMasterVM.ezFieldGroupMaster.Code);
                return Json(new { redirectUrl = Url.Action("Index", "EzFieldGroupMaster", new { Id = ezFieldGroupMasterVM.userRequest.SectionId, UserName = ezFieldGroupMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        private void FillAllControllers()
        {
            // Replace "YourAssemblyName" with the actual name of the assembly you want to inspect.
            string assemblyName = "CRMManagement";

            // Load the assembly.
            Assembly assembly = Assembly.Load(assemblyName);

            // Get all types in the assembly that inherit from Controller (MVC controllers).
            var controllerTypes = assembly.GetTypes().Where(t => typeof(Controller).IsAssignableFrom(t));
            List<SelectListItem> selectList = new List<SelectListItem>();
            // Display the list of controllers.
            Console.WriteLine("Controllers in the assembly:");
            foreach (var controllerType in controllerTypes)
            {
                // Create a new SelectListItem for each item
                SelectListItem listItem = new SelectListItem
                {
                    Text = controllerType.Name,
                    Value = controllerType.Name.Replace("Controller", "")
                    // Set other properties if needed, e.g., Selected
                };

                // Add SelectListItem to the list
                selectList.Add(listItem);
                Console.WriteLine(controllerType.FullName);
            }

            // Get all types in the assembly that inherit from ActionResult (MVC action results).
            var actionResultTypes = assembly.GetTypes().Where(t => typeof(ActionResult).IsAssignableFrom(t));

            // Display the list of action results.
            Console.WriteLine("\nAction Results in the assembly:");
            foreach (var actionResultType in actionResultTypes)
            {
                Console.WriteLine(actionResultType.FullName);
            }
        }
    }
}
