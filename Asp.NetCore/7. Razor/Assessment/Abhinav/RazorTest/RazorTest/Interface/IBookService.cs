using RazorTest.Dto;

namespace RazorTest.Interface
{
    public interface IBookService
    {

        public Task<List<BookDto>> GetAllBookAsync();

        public Task<BookDto> GetBookByIdAsync(int id);

        public Task AddBookAsync(BookDto bookDto);
        public Task DeleteBookAsync(int id);
    }
}
