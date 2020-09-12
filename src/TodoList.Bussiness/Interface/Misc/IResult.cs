using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Bussiness.Interface.Misc
{
    public interface IResult<T> where T : class
    {
        Guid Id { get; set; }

        bool IsSuccess { get; set; }

        string Message { get; set; }

        List<T> ResultItems { get; set; }
    }
}
