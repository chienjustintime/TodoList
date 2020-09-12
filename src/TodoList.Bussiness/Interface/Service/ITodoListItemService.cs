using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Bussiness.Interface.Service
{
    public interface ITodoListItemService
    {
        IEnumerable<TodoListItemDTO> GetAll();
    }
}
