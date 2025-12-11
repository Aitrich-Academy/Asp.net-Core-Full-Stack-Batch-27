using AutoMapper;
using RazorTest.Dto;
using RazorTest.Interface;
using RazorTest.Model;

namespace RazorTest.Service
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<BookDto>> GetAllBookAsync()
        {
            var book= await _repository.GetAllBookAsync();
            return _mapper.Map<List<BookDto>>(book);
        }
        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            var book= _mapper.Map<Book>(bookDto);
            await _repository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteBookAsync(id);
        }
    }
}
