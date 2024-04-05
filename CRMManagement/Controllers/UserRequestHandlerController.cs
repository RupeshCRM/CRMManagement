using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Models.EzUsers;
using EZMasterSetup;

namespace CRMManagement.Controllers
{
    public class UserRequestHandlerController : Controller
    {
        // GET: UserRequestHandler
        public ActionResult ShowLandingPage()
        {
            List<clsUserWorkflowRights> UserWorkflowRights = new List<clsUserWorkflowRights>() 
            {
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A1BC1",ModuleDesc="1ABC"  },
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A2BC1",ModuleDesc="A2BC"  },
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A3BC1",ModuleDesc="A3BC"  },
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A4BC1",ModuleDesc="A4BC"  },
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A5BC1",ModuleDesc="A5BC"  },
                new clsUserWorkflowRights {CmpyCode="01",LoginUserName="Santosh",ModuleCode="A6BC1",ModuleDesc="A6BC"  }
            };


            //new clsUserWorkflowRights(CmpyCode="01",LoginUserName="Santosh",ModuleCode="ABC",ModuleDesc="ABC" )

            //};

            return View(UserWorkflowRights);
        }

        // GET: UserRequestHandler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRequestHandler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRequestHandler/Create
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

        // GET: UserRequestHandler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRequestHandler/Edit/5
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

        // GET: UserRequestHandler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRequestHandler/Delete/5
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
