using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Bussiness.Interface.Service;
using TodoList.Entity.Data;
using TodoList.Entity.Interface;

namespace TodoList.Bussiness.Service
{
    public class TodoListItemService : ITodoListItemService
    {
        private IUnitOfWork _unitOfWork;
        public TodoListItemService(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public IEnumerable<TodoListItemDTO> GetAll()
        {
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var TodoItemEntities = TodoListItemRepo.GetAll();
            var Result = TodoItemEntities.Select(i => new TodoListItemDTO
            {
                Id=i.Id,
                Name=i.Name,
                Order=i.Order
            });
            return Result;
        }
    }
}
