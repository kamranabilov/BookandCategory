using Api_Task_BookandCategory.DAL;
using Api_Task_BookandCategory.DTOs;
using Api_Task_BookandCategory.DTOs.Book;
using Api_Task_BookandCategory.Models;
using Hangfire.MemoryStorage.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Task_BookandCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public BooksController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            BookGetDto getDto = new BookGetDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Year = book.Year,
                Price = book.Price,
                Display = book.Display
            };
            if (book is null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(getDto);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll(int page =1, string search = null)
        {
            List<Book> cars = _context.Books.Where(b => b.Display == true).Skip((page - 1) * 4).Take(4).ToList();
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Name.Contains(search));
            }
            BookListDto listDto = new BookListDto
            {
                BookListItemDtos = query.Select(b => new BookListItemDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Author = b.Author,
                    Price = b.Price,
                    Year = b.Year,
                    Display = b.Display
                })
               .Skip((page - 1) * 4)
               .Take(4).ToList(),
                TotalCount = query.Where(c => c.Display == true).Count()
            };
            return Ok(listDto);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(BookGetDto bookDto)
        {
            if (bookDto is null) return BadRequest(400);
            Book book = new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Price = bookDto.Price,
                Year = bookDto.Year,
                Display = bookDto.Display
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id = book.Id, book = bookDto });
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, BookPostDto bookDto)
        {
            if (id == 0) return BadRequest(401);
            Book existed = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existed == null) return BadRequest(402);
            _context.Entry(existed).CurrentValues.SetValues(bookDto);           
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest(402);
            Book existed = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existed == null) return BadRequest(401);
            _context.Books.Remove(existed);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("change/{id}")]
        public IActionResult ChangeDisplay(int id, bool display)
        {
            if (id == 0) return BadRequest();
            Book existed = _context.Books.FirstOrDefault(c => c.Id == id);
            if (existed == null) return NotFound();
            existed.Display = display;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
