using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Web.Models
{
    public class TodoListItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class TodoListItemUpdateViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}