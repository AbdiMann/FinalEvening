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


        //public ActionResult Create()
        //{
        //    ViewBag.myListJoin = repository.GetListJoin();
        //    return View();
        //}

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


        //public ActionResult List()
        //{
        //     var myList = repository.GetList();
        //    // var myListJoin = repository.GetListJoin();

        //   // ViewBag.myListJoin = repository.GetListJoin();
        //    return View(myList);
        //}



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


        public ActionResult Edit(string ID)
        {
            var myList = repository.GetListForUpdate(ID);
            return View(myList);
        }

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

        public ActionResult Delete(string ID)
        {
            var myList = repository.GetListForUpdate(ID);
            return View(myList);
        }

        [HttpPost]
        public ActionResult Delete(Person delete)
        {
               repository.Delete(delete);
               // TempData["Success"] = "Successfully Updated";
                return RedirectToAction("Delete");


        }



    }
}