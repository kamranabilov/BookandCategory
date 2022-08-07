using Api_Task_BookandCategory.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool? Display { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }

    }
}
