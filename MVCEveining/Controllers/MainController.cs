using MVCEveining.Helpers;
using MVCEveining.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCEveining.Controllers
{
    public class MainController : Controller
    {
        // GET: Main

        PersonClass myModel = new PersonClass();

        public ActionResult Index()
        {
            var persons = myModel.GetPersonInfo();
            return View(persons);
        }


        public ActionResult design()
        {
            return View();
        }





    }
}