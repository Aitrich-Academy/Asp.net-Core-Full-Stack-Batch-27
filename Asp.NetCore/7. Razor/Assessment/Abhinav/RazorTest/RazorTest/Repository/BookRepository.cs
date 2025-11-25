using Microsoft.EntityFrameworkCore;
using RazorTest.Interface;
using RazorTest.Model;

namespace RazorTest.Repository
{
    public class BookRepository:IBookRepository
    {

        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBookAsync()
        {
            var book = await _context.Books.ToListAsync();
            return book;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var books = await _context.Books.FindAsync(id);
            return books;
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
