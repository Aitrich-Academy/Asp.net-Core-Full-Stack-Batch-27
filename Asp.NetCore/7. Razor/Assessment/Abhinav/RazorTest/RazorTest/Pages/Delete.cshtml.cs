using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Dto;
using RazorTest.Interface;

namespace RazorTest.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IBookService _service;

        public DeleteModel(IBookService service)
        {
            _service = service;
        }

        [BindProperty]
        public BookDto BookPost { get;set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           BookPost=await _service.GetBookByIdAsync(id);

            if(BookPost == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
           await _service.DeleteBookAsync(id);
            return RedirectToPage("Read");
        }
    }


}
