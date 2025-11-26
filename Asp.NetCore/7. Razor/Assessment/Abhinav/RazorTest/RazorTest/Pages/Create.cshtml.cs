using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Dto;
using RazorTest.Interface;

namespace RazorTest.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IBookService _service;

        public CreateModel(IBookService service)
        {
            _service = service;
        }

        [BindProperty]
        public BookDto BookPost { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddBookAsync(BookPost);
            return RedirectToPage("Read");
        }
    }
}
