using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.DTOs.Category
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
    }
}
