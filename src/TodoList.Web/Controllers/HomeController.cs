using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Bussiness.Interface.Service;
using TodoList.Entity.Data;
using TodoList.Entity.Interface;

namespace TodoList.Web.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Technologies";

            return View();
        }
    }
}