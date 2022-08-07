using Api_Task_BookandCategory.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Cover { get; set; }
        public List<Book> Books { get; set; }
    }
}
