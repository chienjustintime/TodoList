using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Web.Models
{
    public class TodoListItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}