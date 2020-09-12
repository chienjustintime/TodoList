using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Bussiness.Interface.Misc;

namespace TodoList.Bussiness.Misc
{
    public class Result<T> : IResult<T> where T : class
    {
        public Result(bool Success)
        {
            Id = Guid.NewGuid();
            IsSuccess = Success;
            ResultItems = new List<T>();
        }

        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<T> ResultItems { get; set; }
    }

}
