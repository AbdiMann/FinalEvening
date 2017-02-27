using MVCEveining.Helpers;
using MVCEveining.Models;
using MVCEveining.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEveining.Controllers
{
    public class DataController : Controller
    {

        Repository repository = new Repository();

        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.RegisterCustomers)]
        public ActionResult Create()
        {
            //ViewBag.myListJoin = repository.GetListJoin();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person personClass)
        {
            if (ModelState.IsValid)
            {
                repository.Create(personClass);
                TempData["SuccessMessage"] = "Successfully Saved";
                return RedirectToAction("Create");
            }
            return View();
        }





        public ActionResult Picture(string ID)
        {
            var pic = repository.Getimage1(ID);
            return File(pic, "image/jpeg");
        }

        //public ActionResult List()
        //{
        //     var myList = repository.GetList();
        //    // var myListJoin = repository.GetListJoin();

        //   // ViewBag.myListJoin = repository.GetListJoin();
        //    return View(myList);
        //}


        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.CustomersLst)]
        public ActionResult MyList(string searchTerm)
        {
            var myList = repository.GetList(searchTerm: searchTerm);
            return View(myList);
        }

        //public ActionResult MyList(string searchTerm)
        //{
        //    var myList = repository.GetList(searchTerm: searchTerm);
        //    return  PartialView("_PeopleList",myList);
        //}

        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.Update)]
        public ActionResult Edit(string ID)
        {
            var myList = repository.GetListForUpdate(ID);
            return View(myList);
        }
        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.Update)]
        [HttpPost]
        public ActionResult Edit(Person update)
        {
            {
                repository.Update(update);
                TempData["Success"] = "Successfully Updated";
                return RedirectToAction("Edit");

            }
            return View();
        }

        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.Delete)]
        public ActionResult Delete(string ID)
        {
            var myList = repository.GetListForUpdate(ID);
            return View(myList);
        }
        [PermissionRequired(MVCEveining.ViewModels.LoginForm.Permissions.Delete)]
        [HttpPost]
        public ActionResult Delete(Person delete)
        {
            repository.Delete(delete);
            // TempData["Success"] = "Successfully Updated";
            return RedirectToAction("Delete");
        }


        public ActionResult testtt()
        {
            return View();
        }
    }
}