using System;
using System.Collections.Generic;
using TodoList.Bussiness.DTO;
using TodoList.Bussiness.Interface.Misc;

namespace TodoList.Bussiness.Interface.Service
{
    public interface ITodoListItemService
    {
        IEnumerable<TodoListItemDTO> GetAll();

        IResult<TodoListItemDTO> Create(TodoListItemDTO Instance);

        IResult<TodoListItemDTO> Update(TodoListItemDTO Instance);

        IResult<TodoListItemDTO> Delete(Guid ItemId);

        IResult<TodoListItemDTO> DeleteAll();

        int GetCurrentOrder();
    }
}
