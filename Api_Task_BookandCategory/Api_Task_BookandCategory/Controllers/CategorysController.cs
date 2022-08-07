using Api_Task_BookandCategory.DAL;
using Api_Task_BookandCategory.DTOs.Book;
using Api_Task_BookandCategory.DTOs.Category;
using Api_Task_BookandCategory.Models;
using Hangfire.MemoryStorage.Dto;
using Hangfire.Mongo.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CategorysController(ApiDbContext context) 
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            CategoryGetDto dto = new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
                Cover = category.Cover               
            };
            return Ok();
        }
        //[HttpGet]
        //[Route("getall")]
        //public IActionResult GetAll(int page = 1, string search = null)
        //{
        //    var query = _context.Categories.AsQueryable();
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        query = query.Where(n => n.Name.Contains(search));
        //    }
        //    ListDto<BookListItemDto> ListDto = new ListDto<BookListItemDto>
        //    {
        //        ListItemDtos = query.Select(c => new CategoryListItemDto
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            Cover = c.Cover                  
        //        }).Skip((page - 1) * 4).Take(4).ToList(),
        //        TotalCount = query.Count()
        //    };
        //    return Ok(ListDto);

        //}

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CategoryPostDto categoryDto)
        {
            if (categoryDto == null) return BadRequest(402);
            Category category = new Category
            {
                Name = categoryDto.Name,
                Cover = categoryDto.Cover                
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(202, new { id = category.Id, engine = categoryDto });
        }
    }
}
