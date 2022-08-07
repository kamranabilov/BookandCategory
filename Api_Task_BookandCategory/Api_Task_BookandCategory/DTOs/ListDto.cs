﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.DTOs
{
    public class ListDto<T>
    {
        public List<T> ListItemDtos { get; set; }
        public int TotalCount { get; set; }
    }
}
