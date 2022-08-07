using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.DTOs.Book
{
    public class BookListDto
    {
        public List<BookListItemDto> BookListItemDtos { get; set; }
        public int TotalCount { get; set; }

    }
}
