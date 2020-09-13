using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Bussiness.DTO;
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

        [HttpPost]
        public JsonResult Create(TodoListItemViewModel Instance)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = ModelState.IsValid,
                    ErrorMessage = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors))
                }, JsonRequestBehavior.DenyGet);
            }

            var TodoListItem = new TodoListItemDTO {
                Name = Instance.Name
            };
            var CreateResult = _todoListItemService.Create(TodoListItem);
            if (!CreateResult.IsSuccess) {
                return Json(new
                {
                    IsSuccess= CreateResult.IsSuccess,
                    ErrorMessage = CreateResult.Message
                }, JsonRequestBehavior.DenyGet);
            }
            return Json(new
            {
                IsSuccess = CreateResult.IsSuccess,
                Data= CreateResult.ResultItems.FirstOrDefault()
            }, JsonRequestBehavior.DenyGet);

        }

        [HttpPost]
        public JsonResult Update(TodoListItemUpdateViewModel Instance)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    IsSuccess = ModelState.IsValid,
                    ErrorMessage = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors))
                }, JsonRequestBehavior.DenyGet);
            }

            var TodoListItem = new TodoListItemDTO
            {
                Name = Instance.Name
            };
            var UpdateResult = _todoListItemService.Update(TodoListItem);
            if (!UpdateResult.IsSuccess)
            {
                return Json(new
                {
                    IsSuccess = UpdateResult.IsSuccess,
                    ErrorMessage = UpdateResult.Message
                }, JsonRequestBehavior.DenyGet);
            }

            return Json(new
            {
                IsSuccess = UpdateResult.IsSuccess,
                Data = UpdateResult.ResultItems.FirstOrDefault()
            }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Delete(TodoListItemUpdateViewModel Instance)
        {

            if (!ModelState.IsValid) {
                return Json(new
                {
                    IsSuccess = ModelState.IsValid,
                    ErrorMessage =string.Join(", ", ModelState.Values.SelectMany(v => v.Errors)) 
                }, JsonRequestBehavior.DenyGet);
            }

            var TodoListItem = new TodoListItemDTO
            {
                Name = Instance.Name
            };
            var UpdateResult = _todoListItemService.Delete(Instance.Id);
            if (!UpdateResult.IsSuccess)
            {
                return Json(new
                {
                    IsSuccess = UpdateResult.IsSuccess,
                    ErrorMessage = UpdateResult.Message
                }, JsonRequestBehavior.DenyGet);
            }

            return Json(new
            {
                IsSuccess = UpdateResult.IsSuccess,
                Data = UpdateResult.ResultItems.FirstOrDefault()
            }, JsonRequestBehavior.DenyGet);
        }


    }
}