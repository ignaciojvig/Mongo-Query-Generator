using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoQueryGenerator.Domain.Interfaces;
using MongoQueryGenerator.Schema;
using MongoQueryGenerator.Services;

namespace MongoQueryGenerator.Controllers
{
    [Route("api/querygen/")]
    [ApiController]
    public class QueryGeneratorController : ControllerBase
    {
        private readonly IQueryGeneratorService _bookService;

        public QueryGeneratorController(IQueryGeneratorService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            return _bookService.GetQuery();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<BookSchema> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<BookSchema> Create(BookSchema book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, BookSchema bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}