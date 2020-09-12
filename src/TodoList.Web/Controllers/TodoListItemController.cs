using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Bussiness.Interface.Service;
using TodoList.Web.Models;

namespace TodoList.Web.Controllers
{
    public class TodoListItemController : Controller
    {

        private ITodoListItemService _todoListItemService;

        public TodoListItemController(ITodoListItemService TodoListItemService)
        {
            _todoListItemService = TodoListItemService;
        }
        // GET: TodoListItem
        public JsonResult GetAll()
        {
            var TodoListItems = _todoListItemService.GetAll();
            var Result = TodoListItems.Select(d => new TodoListItemViewModel {
                Id=d.Id,
                Name=d.Name,
                LastModifiedDate=d.LastModifiedDate
            });

            return Json(new 
            {
                count= Result.Count(),
                data = Result
            }, JsonRequestBehavior.AllowGet);
        }


    }
}