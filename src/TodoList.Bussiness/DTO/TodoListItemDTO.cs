﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Bussiness.DTO
{
    public class TodoListItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order  { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
