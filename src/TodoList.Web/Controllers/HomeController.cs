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
        private ITodoListItemService _todoListItemService;

        public HomeController(ITodoListItemService TodoListItemService)
        {
            _todoListItemService = TodoListItemService;
        }

        public ActionResult Index()
        {
            //_todoListItemRepo.Create(new TodoListItem
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "test",
            //    Note = "testsetst",
            //    Order = 1
            //});
            //_unitOfWork.SaveChanges();
            var result =_todoListItemService.GetAll().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Technologies";

            return View();
        }
    }
}