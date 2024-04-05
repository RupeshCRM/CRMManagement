using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMManagement.Models
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase httpContext = filterContext.HttpContext;

            // Check if the session has expired
            if (httpContext.Session != null && httpContext.Session.IsNewSession)
            {
                string sessionCookie = httpContext.Request.Headers["Cookie"];
                if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    // The session has expired, redirect to the login page or any other page
                    filterContext.Result = new RedirectResult("~/Authentication/Index");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
  
    
}