using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Entity.Data;
using TodoList.Entity.Interface;

namespace TodoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<TodoListItem> _todoListItemRepo;
        private IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
            _todoListItemRepo = UnitOfWork.Repository<TodoListItem>();
        }

        public ActionResult Index()
        {
            _todoListItemRepo.Create(new TodoListItem
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Note = "testsetst",
                Order = 1
            });
            _unitOfWork.SaveChanges();
            var result = _todoListItemRepo.GetAll().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}