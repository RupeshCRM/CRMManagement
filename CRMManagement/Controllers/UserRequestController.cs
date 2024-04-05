using CRM.BAL;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMManagement.Models;
using EZMasterSetup;

namespace CRMManagement.Controllers
{
    public class UserRequestController : Controller
    {

        clsUserRequest userRequest;

        clsEzTemplateMasterBAL EzTemplateMasterBAL;
        clsSectionMasterBAL SectionMasterBAL;
        clsUserInformation userInformation;
        clsWorkflowInformation workflowInformation;

        public class SelectListItemComparer : IEqualityComparer<SelectListItem>
        {
            public bool Equals(SelectListItem x, SelectListItem y)
            {
                return x != null && y != null && x.Value == y.Value;
            }

            public int GetHashCode(SelectListItem obj)
            {
                return obj.Value.GetHashCode();
            }
        }
        // GET: UserRequest
        public ActionResult Index(string Id, string UserName)
        {
            userRequest = new clsUserRequest();
            EzTemplateMasterBAL = new clsEzTemplateMasterBAL();
            SectionMasterBAL = new clsSectionMasterBAL();
            userInformation=new clsUserInformation();
            workflowInformation = new clsWorkflowInformation();

            int intSno = 1;
            clsControls controls;
            clsControlsVM controlsVM;

            List<clsListValues> lstEmployee = new List<clsListValues> {
            new clsListValues{Code="001",Description="Santosh Kundhare" },
            new clsListValues{Code="002",Description="Santosh 001" },
            new clsListValues{Code="003",Description="Santosh 002" },
            new clsListValues{Code="004",Description="Santosh 003" },
            };

            List<clsControls> objControls = new List<clsControls>();
            List<clsEzTemplateMaster> EzTemplateMasterBALList = EzTemplateMasterBAL.GetByIdList(Id);
            foreach (var item in EzTemplateMasterBALList)
            {
                controls = new clsControls();

                controls.LableName = item.LableName;
                controls.FieldName = item.DBFieldName;
                controls.ControlType = item.MVCControlType;
                controls.SectionName = item.SectionDesc;
                controls.SectionId = item.Sno;
                controls.SectionCode = item.SectionCode;
                controls.isApplicableForTable = item.isApplicableForTable;
                controls.DbFieldType = item.DBFieldDataType;
                controls.isRequired = item.isRequired;
                controls.listValues = lstEmployee.Select(e => new SelectListItem { Value = e.Code, Text = e.Description }).ToList();
                objControls.Add(controls);

                //Workflow Information
                workflowInformation.ModuleDesc = item.ProjectName;
                workflowInformation.WorkflowCode= item.WorkflowCode;
                workflowInformation.WorkflowDesc = item.WorkflowDescription;
                workflowInformation.SectionCode = item.SectionCode;
                workflowInformation.SectionDesc = item.SectionDesc;

                intSno = intSno + 1;
            }

            controls = new clsControls();
            controlsVM = new clsControlsVM();
            controlsVM.controls = objControls;

            //User Information
            userInformation.UserName = UserName;
            userInformation.Create = 1;
            userInformation.Edit = 1;
            userInformation.Delete= 1;
            userInformation.Save = 1;
            controlsVM.sectionMaster = SectionMasterBAL.GetByIdList(Id, "WorkflowCode");
            controlsVM.workflowInformation = workflowInformation;
            controlsVM.userInformation= userInformation;
            //controlsVM.sectionValues = EzTemplateMasterBALList.Select(e => new SelectListItem { Value = e.SectionFk.ToString(), Text = e.SectionDesc})
            //    .Distinct(new SelectListItemComparer())
            //    .ToList();
            return View(controlsVM);


            //userRequest.SectionId = Id;
            //userRequest.UserName = UserName;
            //return View(userRequest);
        }

        // GET: UserRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRequest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
