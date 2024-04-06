using CRM.Models.EzUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using System.Web.UI.WebControls;
using System.Reflection;
using CRM.BAL.EzUsers;
using CRM.Models;
using EZMasterSetup;
 using CRM.Models.Configuration;
using CRM.BAL.CRM;
using CRMManagement.Models;
using static System.Collections.Specialized.BitVector32;
using CRM.ModelsVM.CRM;
namespace CRMManagement.Controllers.EzUsers
{
    [SessionExpireFilter]
    public class UserLandingPageController : Controller
    {
        // GET: UserLandingPage
        public ActionResult Index(string sectionId, string UserName, string FYear, string CompanyCode)
        {
            clsEzWorkflowMasterBAL ezWorkflowMasterBAL=new clsEzWorkflowMasterBAL();
            clsDashboardVM DashboardVM=new clsDashboardVM();
            DashboardVM.EzWorkflowMasterList=ezWorkflowMasterBAL.GetAll();
            DashboardVM.UserName = UserName;
            ViewBag.UserName = UserName;
            ViewBag.FYear = FYear;
            ViewBag.CompanyCode = CompanyCode;
            GlobalVariable.CmpyCode=CompanyCode;
            return View(DashboardVM);

        }

        public ActionResult GetPartialData_list()
        {
            string UserName = (string)Session["UserName"];
            string CompanyCode = (string)Session["CompanyCode"];
            string FYear = (string)Session["FYear"];

            clsUserWorkflowRightsBAL userWorkflowRightsBAL = new clsUserWorkflowRightsBAL();

            List<clsUserWorkflowRights> workflowList = userWorkflowRightsBAL.GetByIdList_Admin(UserName);
            List<clsUserWiseWorkflow> UserWorkflowRights = new List<clsUserWiseWorkflow>();
            clsUserWiseWorkflow UserWiseWorkflow;
            foreach (var item in workflowList)
            {
                UserWiseWorkflow = new clsUserWiseWorkflow();
                UserWiseWorkflow.CmpyCode = CompanyCode.Trim();
                UserWiseWorkflow.UserName = UserName.Trim();
                UserWiseWorkflow.ControllerName = item.ControllerName.Trim();
                UserWiseWorkflow.WorkflowCode = item.WorkflowCode.Trim();
                UserWiseWorkflow.WorkflowDesc = item.WorkflowDesc.Trim();
                UserWiseWorkflow.ModuleCode = item.ModuleCode.Trim();
                UserWiseWorkflow.ModuleDesc = item.ModuleDesc.Trim();
                UserWiseWorkflow.icon = "fa fa-home";
                UserWiseWorkflow.DefaultActionMethod = item.DefaultActionMethod.Trim();
                UserWorkflowRights.Add(UserWiseWorkflow);
            }

            return PartialView("_userWorkflowRights", UserWorkflowRights);
        }

        public JsonResult GetPartialData()
        {
            string UserName = (string)Session["UserName"];
            string CompanyCode = (string)Session["CompanyCode"];
            string FYear = (string)Session["FYear"];

            clsUserWorkflowRightsBAL userWorkflowRightsBAL = new clsUserWorkflowRightsBAL();
            List<clsUserWorkflowRights> workflowList = userWorkflowRightsBAL.GetByIdList_Admin("Admin");
            List<clsUserWiseWorkflow> UserWorkflowRights = new List<clsUserWiseWorkflow>();
            clsUserWiseWorkflow UserWiseWorkflow;
            foreach (var item in workflowList)
            {
                UserWiseWorkflow = new clsUserWiseWorkflow();
                UserWiseWorkflow.CmpyCode = CompanyCode.Trim();
                UserWiseWorkflow.UserName = UserName.Trim();
                UserWiseWorkflow.ControllerName = item.ControllerName.Trim();
                UserWiseWorkflow.WorkflowCode = item.WorkflowCode.Trim();
                UserWiseWorkflow.WorkflowDesc = item.WorkflowDesc.Trim();
                UserWiseWorkflow.ModuleCode = item.ModuleCode.Trim();
                UserWiseWorkflow.ModuleDesc = item.ModuleDesc.Trim();
                UserWiseWorkflow.icon = "fa fa-home";
                UserWiseWorkflow.DefaultActionMethod = item.DefaultActionMethod.Trim();
                UserWorkflowRights.Add(UserWiseWorkflow);
            }


            string str = "";
            string strList = "";

            strList = " <h3>General</h3>";
            strList = strList + "<ul class=\"nav side-menu\"> <li>";
            strList = strList + "<a><i class=\"fa fa-home\"></i> Home <span class=\"fa fa-chevron-down\"></span></a>";
            strList = strList + "<ul class=\"nav child_menu\">";

            foreach (var child in UserWorkflowRights.OrderBy(e => e.ModuleCode))
            {
                str = "<li><a href=" + child.ControllerName + "/Index?CmpyCode=" + child.CmpyCode + "&Id=" + child.WorkflowCode + "&UserName=" + child.UserName + ">" + child.WorkflowDesc + "</a></li>";
                strList = strList + str;
            }

            strList = strList + "</ul></li></ul>";
            return Json(strList, JsonRequestBehavior.AllowGet);
            //return Json(strList, JsonRequestBehavior.AllowGet);
        }
        // GET: UserLandingPage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserLandingPage/Create
        public ActionResult Create(string CmpyCode, string Id, string userName)
        {
            clsEzWorkflowMasterBAL EzWorkflowMasterBAL=new clsEzWorkflowMasterBAL();
            clsEzWorkflowMaster EzWorkflowMaster=EzWorkflowMasterBAL.ReadSingle(Id);
            return RedirectToAction("Create", EzWorkflowMaster.ControllerName, new { CmpyCode=CmpyCode,Id=Id,userName=userName  });
      
        }

        // POST: UserLandingPage/Create
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                // TODO: Add insert logic here
                
      
            return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserLandingPage/Edit/5
        public ActionResult Edit(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                clsEzWorkflowMasterBAL EzWorkflowMasterBAL=new clsEzWorkflowMasterBAL();
                clsEzWorkflowMaster EzWorkflowMaster=EzWorkflowMasterBAL.ReadSingle(SectionId);
                return RedirectToAction("Edit", EzWorkflowMaster.ControllerName, new { CmpyCode=CmpyCode,SectionId=SectionId,Id=Id,userName=userName  });
            }
            catch (Exception)
            {

                return View("");
            }
          

            
        }

        // POST: UserLandingPage/Edit/5
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

        // GET: UserLandingPage/Delete/5
        public ActionResult Delete(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                clsEzWorkflowMasterBAL EzWorkflowMasterBAL=new clsEzWorkflowMasterBAL();
                clsEzWorkflowMaster EzWorkflowMaster=EzWorkflowMasterBAL.ReadSingle(SectionId);
                return RedirectToAction("Delete", EzWorkflowMaster.ControllerName, new { CmpyCode=CmpyCode,SectionId=SectionId,Id=Id,userName=userName  });
            }
            catch (Exception)
            {

                return View("");
            }
        }

        // POST: UserLandingPage/Delete/5
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

        
        clsUserRequestHandler UserRequestHandler;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsControlsVM ControlsVM;
        
       public ActionResult RefreshDetail(string Id)
        {
            try
            {
                 string UserName = (string)Session["UserName"];
                 string CompanyCode = (string)Session["CompanyCode"];
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, UserName, CompanyCode);
                ViewBag.SectionId = Id;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
          return PartialView("RefreshDetail", ControlsVM);
        }

        [HttpGet]
        public ActionResult HistoryDetail(string ReferenceId)
        {
            try
            {
                string UserName = (string)Session["UserName"];
                string CompanyCode = (string)Session["CompanyCode"];
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.DisplayRecord(ReferenceId, UserName, CompanyCode);
                ViewBag.SectionId = ReferenceId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
          return PartialView("RefreshDetail", ControlsVM);
        }

        public ActionResult NewHistory(clsCRMHistoryDetailVM CRMHistoryDetailVM) //
        {
            try
            {
                clsCRMHistoryDetailBAL CRMHistoryDetailBAL=new clsCRMHistoryDetailBAL();
                string UserName = (string)Session["UserName"];
                string CompanyCode = (string)Session["CompanyCode"];
                CRMHistoryDetailVM.CRMHistoryDetail.CmpyCode=CompanyCode;
                CRMHistoryDetailVM.CRMHistoryDetail.UserName=UserName;
                CRMHistoryDetailVM.CRMHistoryDetail.Dates=DateTime.Now;
                CRMHistoryDetailBAL.Insert(CRMHistoryDetailVM.CRMHistoryDetail);
                 return View(true);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
              
            }
                
        
               
        
        }
        

    }
}
 