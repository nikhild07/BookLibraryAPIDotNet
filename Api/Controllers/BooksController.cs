using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>();
        private static int nextId = 1;

        //Ping
        [HttpGet("Ping")]
        public string Ping()
        {
            return "Running...Alive!";
        }

        // GET: api/Books
        [HttpGet("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            return Ok(books);
        }

        // GET: api/Books/1
        [HttpGet("getbookbyid/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound("Book Not found");

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost("addbook")]
        public IActionResult AddBook(Book book)
        {
            int id = nextId++;
            book = new Book()
            {
                Id = id,
                Author = book.Author,
                Title = book.Title,
                Price = book.Price
            };
            books.Add(book);
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost("addbookbyurl")]
        public IActionResult AddBookbyUrl(Book book)
        {
            book.Id = nextId++;
            books.Add(book);

            return CreatedAtAction(
                nameof(GetBookById),
                new { id = book.Id },
                book
            );
        }

        // PUT: api/Books/1
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound("Book not found.");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;

            return Ok(book);
        }

        // DELETE: api/Books/1
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound("Book not found.");

            books.Remove(book);
            return Ok("Book deleted successfully.");
        }
    }
}
