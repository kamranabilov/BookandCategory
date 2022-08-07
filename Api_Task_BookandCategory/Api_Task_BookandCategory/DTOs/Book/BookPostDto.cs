using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.DTOs.Book
{
    public class BookPostDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool? Display { get; set; }
    }
}
