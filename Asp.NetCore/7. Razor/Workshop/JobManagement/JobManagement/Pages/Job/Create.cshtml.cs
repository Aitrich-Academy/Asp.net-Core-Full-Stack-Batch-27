using JobManagement.Dto;
using JobManagement.Interface;
using JobManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobManagement.Pages.Job
{
    public class CreateModel : PageModel
    {
        private readonly IJobService _service;

        [BindProperty]
        public JobDto JobPost { get; set; }

        public CreateModel(IJobService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.AddJobAsync(JobPost);
            return RedirectToPage("Index");
        }
    }
}
