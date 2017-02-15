using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCEveining.Models;
using MVCEveining.ViewModels;


namespace MVCEveining.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication

        Repository repository = new Repository();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {
                var user = repository.Authenticate(loginForm.UserName,loginForm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid Username or Password.";
                }
            }

            return View(loginForm) ;
        }


        public ActionResult UsersList()
        {
            var getusers = repository.GetUsers();
            return View(getusers);
        }





        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(LoginForm users)
        {
            if (repository != null)
            {
                repository.CreateUsers(users);
          
                TempData["SuccessMessage"] = "User updated successfully.";

            }
            return RedirectToAction("UpdateUser", new { UserId = users.UserName });
        }

        // [PermissionRequired(MVCEveining.ViewModels.Users.Permissions.Update_Users)]
        public ActionResult UpdateUser(string userId)
        {
            var user = repository.GetUser(userId);

            if (user == null) return View("UserNotFound");

            var userForm = new UpdateUserForm(user);

            ViewBag.Permissions = MVCEveining.Helpers.EnumHelpers.ToDictionary<MVCEveining.ViewModels.LoginForm.Permissions>();
            return View(userForm);
        }

        //   [PermissionRequired(MVCEveining.ViewModels.Users.Permissions.Update_Users)]
        [HttpPost]
        public ActionResult UpdateUser([ModelBinder(typeof(UserFormModelBinder))] UpdateUserForm updateUserForm)
        {
            if (repository != null)
            {
                repository.UpdateUser(updateUserForm);
                HttpContext.Cache[string.Format("{0}'s CurrentPermissions", updateUserForm.UserName)] = updateUserForm.CurrentPermissions;
                ViewBag.Permissions = MVCEveining.Helpers.EnumHelpers.ToDictionary<MVCEveining.ViewModels.LoginForm.Permissions>();
                TempData["SuccessMessage"] = "User updated successfully.";
          
            }
            return RedirectToAction("UpdateUser", new { UserId = updateUserForm.UserName });
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            TempData["SuccessMessage"] = "You have been logged out of the system.";
            return RedirectToAction("Login");
        }
    }
}