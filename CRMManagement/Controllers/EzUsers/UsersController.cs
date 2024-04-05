using CRM.BAL;
using CRM.BAL.EzUsers;
using CRM.Models;
using CRMManagement.Models;
using CRM.Models.EzUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using EZMasterSetup;

namespace CRMManagement.Controllers.EzUsers
{
    [SessionExpireFilter]
    public class UsersController : Controller
    {
        clsUsersBAL ezUserBAL;
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
        public ActionResult Create(string CmpyCode,string Id, string userName)
        {
            try
            {
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_CreateMode("uVw_UsersNewEntry", Id,userName, "SectionCode", CmpyCode);
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
        public ActionResult Create(clsUsersVM usersVM)
        {
            try
            {
                clsUsers users = new clsUsers();
                ezUserBAL = new clsUsersBAL();
                comFunction = new clsCommonFunction();
                object ezUserWorkflowRights = new clsUserWorkflowRights();
                ezUserWorkflowRightsBAL = new clsUserWorkflowRightsBAL();

                ezUserWorkflowRights = usersVM.userWorkflowRightsList;
                
                users = usersVM.users;
                ezUserBAL.Insert(users);
                foreach (var item in usersVM.userWorkflowRightsList.Where(e => e.LoginUserName != null && e.CmpyCode != null))
                {
                    userWorkflowRights = new clsUserWorkflowRights();
                    ezUserWorkflowRights = comFunction.CopyProperties(item, userWorkflowRights);
                    ezUserWorkflowRightsBAL.Insert(userWorkflowRights);
                }
                return Json(new { redirectUrl = Url.Action("Index", "Users", new {CmpyCode=usersVM.userRequest.CompanyCode, Id = usersVM.userRequest.SectionId, UserName = usersVM.userRequest.UserName }) });
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
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "LoginUserName", CmpyCode);
               ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }
        // Method to copy properties using reflection
      
        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsUsersVM usersVM)
        {
            try
            {
                
                object ezUsers = new clsUsers();
                object ezUserWorkflowRights = new clsUserWorkflowRights();

                ezUserBAL = new clsUsersBAL();
                ezUserWorkflowRightsBAL=new clsUserWorkflowRightsBAL();

                comFunction = new clsCommonFunction();

                ezUsers = usersVM.users;
                ezUserWorkflowRights=usersVM.userWorkflowRightsList; 

                ezUsers = comFunction.CopyProperties(usersVM.users, ezUsers);


                //ezUserBAL.Delete(usersVM.users.LoginUserName);
                ezUserWorkflowRightsBAL.Delete(usersVM.users.LoginUserName);

                ezUserBAL.Update(ezUsers, usersVM.users.LoginUserName);
                foreach (var item in usersVM.userWorkflowRightsList.Where(e=>e.LoginUserName!=null && e.CmpyCode!= null))
                {
                    userWorkflowRights = new clsUserWorkflowRights();
                    ezUserWorkflowRights = comFunction.CopyProperties(item, userWorkflowRights);
                    ezUserWorkflowRightsBAL.Insert(item);
                }
                return Json(new { redirectUrl = Url.Action("Index", "Users", new { CmpyCode = usersVM.userRequest.CompanyCode, Id = usersVM.userRequest.SectionId, UserName = usersVM.userRequest.UserName }) });
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
                comFunction = new clsCommonFunction();
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "LoginUserName", CmpyCode);
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
        public ActionResult Delete(clsUsersVM usersVM)
        {
            try
            {
                ezUserBAL = new clsUsersBAL();
                ezUserWorkflowRightsBAL = new clsUserWorkflowRightsBAL();

                ezUserBAL.Delete(usersVM.users.LoginUserName);
                ezUserWorkflowRightsBAL.Delete(usersVM.users.LoginUserName);
                return Json(new { redirectUrl = Url.Action("Index", "Users", new { CmpyCode = usersVM.userRequest.CompanyCode, Id = usersVM.userRequest.SectionId, UserName = usersVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
