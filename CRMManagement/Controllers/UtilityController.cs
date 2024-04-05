using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CRM.Models;
using CRM.BAL;
using CRMManagement.Models;
using EZMasterSetup;

namespace CRMManagement.Controllers
{
    public class UtilityController : Controller
    {
        clsEzTemplateMasterBAL EzTemplateMasterBAL;
        clsSectionMasterBAL SectionMasterBAL;

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

        // GET: Utility
        public ActionResult Index()
        {
            EzTemplateMasterBAL = new clsEzTemplateMasterBAL();
            SectionMasterBAL= new clsSectionMasterBAL();


            int intSno=1;
            clsControls controls;
            clsControlsVM controlsVM;

            List<clsListValues> lstEmployee = new List<clsListValues> {
            new clsListValues{Code="001",Description="Santosh Kundhare" },
            new clsListValues{Code="002",Description="Santosh 001" },
            new clsListValues{Code="003",Description="Santosh 002" },
            new clsListValues{Code="004",Description="Santosh 003" },
            };

            List<clsControls> objControls = new List<clsControls>();
            List<clsEzTemplateMaster> EzTemplateMasterBALList=EzTemplateMasterBAL.GetAll();
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

                controls.listValues= lstEmployee.Select(e => new SelectListItem { Value = e.Code, Text = e.Description }).ToList();
                objControls.Add(controls);

                intSno = intSno + 1;

            }

            controls = new clsControls();
            controlsVM = new clsControlsVM();
            controlsVM.controls = objControls;
       
            controlsVM.sectionMaster = SectionMasterBAL.GetByIdList(controls.SectionId.ToString(), "WorkflowCode");
            //controlsVM.sectionValues = EzTemplateMasterBALList.Select(e => new SelectListItem { Value = e.SectionFk.ToString(), Text = e.SectionDesc})
            //    .Distinct(new SelectListItemComparer())
            //    .ToList();
            return View(controlsVM);
        }

        // GET: Utility/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utility/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utility/Create
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

        // GET: Utility/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utility/Edit/5
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

        // GET: Utility/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utility/Delete/5
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
