using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Bussiness.DTO;
using TodoList.Bussiness.Interface.Misc;
using TodoList.Bussiness.Interface.Service;
using TodoList.Bussiness.Misc;
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

        public IResult<TodoListItemDTO> Create(TodoListItemDTO Instance)
        {
            var Result=new Result<TodoListItemDTO>(true);
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var TodoItemEntity = new TodoListItem
            {
                Id=Guid.NewGuid(),
                Name= Instance.Name,
                Order= GetCurrentOrder(),
                CreatedDate=DateTime.UtcNow,
                LastModifiedDate=DateTime.UtcNow,
            };
            try
            {
                TodoListItemRepo.Create(TodoItemEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                Result.IsSuccess = false;
                Result.Message = ex.Message;
            }
 
            return Result;
        }

        public IResult<TodoListItemDTO> Delete(Guid ItemId)
        {
            var Result = new Result<TodoListItemDTO>(true);
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var TodoItemEntities = TodoListItemRepo.GetBy(d => d.Id == ItemId);
            var TodoItemEntity = TodoItemEntities.FirstOrDefault();
            if (TodoItemEntity == null)
            {
                Result.IsSuccess = false;
                Result.Message = "can't find this entity";
                return Result;
            }

            try
            {
                TodoListItemRepo.Delete(TodoItemEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                Result.IsSuccess = false;
                Result.Message = ex.Message;
            }

            return Result;
        }

        public IResult<TodoListItemDTO> DeleteAll()
        {
            var Result = new Result<TodoListItemDTO>(true);
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var TodoItemEntities = TodoListItemRepo.GetAll();
            if (TodoItemEntities.Count()==0)
            {
                return Result;
            }

            foreach (var item in TodoItemEntities) {
                TodoListItemRepo.Delete(item);
            }

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                Result.IsSuccess = false;
                Result.Message = ex.Message;
            }
            return Result;
        }

        public IEnumerable<TodoListItemDTO> GetAll()
        {
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var TodoItemEntities = TodoListItemRepo.GetAll();
            var Result = TodoItemEntities.Select(i => new TodoListItemDTO
            {
                Id=i.Id,
                Name=i.Name,
                Order=i.Order,
                LastModifiedDate=i.LastModifiedDate
            });
            return Result;
        }

        public int GetCurrentOrder()
        {
            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();
            var OrderNumbers = TodoListItemRepo.GetAll().OrderBy(d => d.Order).Select(d => d.Order).ToList();
            if (OrderNumbers.Count() != 0)
            {
                int maxVersionNumber = OrderNumbers.LastOrDefault() + 1;
                return maxVersionNumber;
            }
            return 1;
        }

        public IResult<TodoListItemDTO> Update(TodoListItemDTO Instance)
        {
            var Result = new Result<TodoListItemDTO>(true);

            var TodoListItemRepo = _unitOfWork.Repository<TodoListItem>();

            var TodoItemEntities = TodoListItemRepo.GetBy(d => d.Id == Instance.Id);
            var TodoItemEntity = TodoItemEntities.FirstOrDefault();
            if (TodoItemEntity == null) {
                Result.IsSuccess = false;
                Result.Message = "can't find this entity";
                return Result;
            }

            TodoItemEntity.Name = Instance.Name;

            TodoItemEntity.Order = Instance.Order;

            TodoItemEntity.LastModifiedDate = DateTime.UtcNow;

            try
            {
                TodoListItemRepo.Update(TodoItemEntity);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                Result.IsSuccess = false;
                Result.Message = ex.Message;
            }

            return Result;
        }
        
    }
}
