using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEveining.ViewModels;

namespace MVCEveining.Helpers
{
    public class PermissionRequired : ActionFilterAttribute
    {
        LoginForm.Permissions expectedPermissions;

        public PermissionRequired(LoginForm.Permissions permissions = LoginForm.Permissions.None)
        {
            this.expectedPermissions = permissions;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionResult unauthorizedActionResult = new ViewResult { ViewName = "Unauthorized" };
            ActionResult logoutActionResult = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Authentication", action = "Logout", returnUrl = filterContext.HttpContext.Request.RawUrl }));

            var user = filterContext.HttpContext.Session["User"] as LoginForm;

            if (user == null)
            {
                filterContext.Result = logoutActionResult;
                return;
            }

            //var userCurrentPermissions = user.CurrentPermissions;
            var userCurrentPermissions = (LoginForm.Permissions)HttpContext.Current.Cache[string.Format("{0}'s CurrentPermissions", user.UserName)];

            if (((userCurrentPermissions & expectedPermissions) != expectedPermissions))
                filterContext.Result = unauthorizedActionResult;
        }
    }
}