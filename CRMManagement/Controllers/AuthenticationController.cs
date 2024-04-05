using CRM.BAL;
using CRM.BAL.EzUsers;
using CRMManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using EZMasterSetup;

namespace CRMManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        clsCommonFunction ComFunction;
        clsUsersBAL UsersBAL;
        
        // GET: Authentication
        public ActionResult Index()
        {
           
            clsAuthenticationVM authenticationVM=new clsAuthenticationVM();
            ComFunction =new clsCommonFunction();
            authenticationVM.CompanyName = "01";
            authenticationVM.CompanyYear = "2024-01-01";
            authenticationVM.FinancialYear = ComFunction.FillControls("CompanyYear", "StartDate", "EndDate", authenticationVM.CompanyName," order by StartDate Desc");
            authenticationVM.Company = ComFunction.FillControls("CompanyMaster", "Name", "CmpyCode");
            return View(authenticationVM);
        }

        // GET: Authentication/Details/5
        [HttpPost]
        public ActionResult Login(clsAuthenticationVM AuthenticationVM)
        {

       
            ComFunction = new clsCommonFunction();

            Boolean LoginSuccess =ComFunction.validateUserLogin(AuthenticationVM.UserName, AuthenticationVM.Password, AuthenticationVM.CompanyName);
            var jsonData = new
            {
                UserName = AuthenticationVM.UserName,
                CompanyCode = AuthenticationVM.CompanyName,
                FYear = AuthenticationVM.CompanyYear,
                LoginSuccess= LoginSuccess,
            };
            Session["UserName"] = AuthenticationVM.UserName;
            Session["CompanyCode"] = AuthenticationVM.CompanyName;
            Session["FYear"] = AuthenticationVM.CompanyYear;
            Session["LoginSuccess"] = LoginSuccess;
            // Serialize the object to JSON
            var json = JsonConvert.SerializeObject(jsonData);
            return Json(json, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LoginSuccess(clsAuthenticationVM AuthenticationVM)
        {
            
            //CRM.BAL.Class1 class1 = new CRM.BAL.Class1(AuthenticationVM.CompanyName); // For passing Company Code to Business Logic
            return Json(new { redirectUrl = Url.Action("Index", "UserLandingPage", new { sectionId = "", UserName = AuthenticationVM.UserName, FYear = AuthenticationVM.CompanyYear, CompanyCode=AuthenticationVM.CompanyName }) }); 
            
        }
        
        // GET: Authentication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authentication/Create
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

        // GET: Authentication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authentication/Edit/5
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

        // GET: Authentication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authentication/Delete/5
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
