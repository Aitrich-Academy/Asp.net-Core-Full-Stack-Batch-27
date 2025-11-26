using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Dto;
using RazorTest.Interface;

namespace RazorTest.Pages
{
    public class ReadModel : PageModel
    {
        private readonly IBookService _service;

        public ReadModel(IBookService service)
        {
            _service = service;
        }

        [BindProperty]
        public List<BookDto> BookPost { get; set; }

        public async Task OnGetAsync()
        {
            BookPost=await _service.GetAllBookAsync();
        }
    }
}
