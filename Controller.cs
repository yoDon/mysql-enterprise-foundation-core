using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace SampleMySqlEfCore
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly SampleDbContext mDbContext;

        public BookController(SampleDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<BookDTO>>> Get()
        {
            var list = await mDbContext.Books.Select(
                s => new BookDTO
                {
                    BookId = s.BookId,
                    Title = s.Title,
                    AuthorName = s.AuthorName,
                    PublicationDate = s.PublicationDate,
                }
            ).ToListAsync();

            if (list.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return list;
            }
        }

        [HttpGet("GetBookById")]
        public async Task<ActionResult<BookDTO>> GetBookById(int bookId)
        {
            var book = await mDbContext.Books.Select(
                    s => new BookDTO
                    {
                        BookId = s.BookId,
                        Title = s.Title,
                        AuthorName = s.AuthorName,
                        PublicationDate = s.PublicationDate,
                    })
                .FirstOrDefaultAsync(s => s.BookId == bookId);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return book;
            }
        }

        [HttpPost("InsertBook")]
        public async Task<HttpStatusCode> InsertBook(BookDTO book)
        {
            var entity = new Book()
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.AuthorName,
                PublicationDate = book.PublicationDate,
            };

            mDbContext.Books.Add(entity);
            await mDbContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        [HttpPut("UpdateBook")]
        public async Task<HttpStatusCode> UpdateBook(BookDTO book)
        {
            var entity = await mDbContext.Books.FirstOrDefaultAsync(s => s.BookId == book.BookId);

            entity.Title = book.Title;
            entity.AuthorName = book.AuthorName;
            entity.PublicationDate = book.PublicationDate;

            await mDbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteBook")]
        public async Task<HttpStatusCode> DeleteBook(int bookId)
        {
            var entity = new Book()
            {
                BookId = bookId,
            };
            mDbContext.Books.Attach(entity);
            mDbContext.Books.Remove(entity);
            await mDbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
