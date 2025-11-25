using RazorTest.Model;

namespace RazorTest.Interface
{
    public interface IBookRepository
    {

        public Task<List<Book>> GetAllBookAsync();

        public Task<Book> GetBookByIdAsync(int id);

        public Task AddBookAsync(Book book);

        public Task DeleteBookAsync(int id);

    }
}
