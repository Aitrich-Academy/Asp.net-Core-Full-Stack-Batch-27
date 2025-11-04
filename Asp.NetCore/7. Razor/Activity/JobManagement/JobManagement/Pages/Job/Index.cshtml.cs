using JobManagement.Dto;
using JobManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobManagement.Pages.Job
{
    public class IndexModel : PageModel
    {
        private readonly JobService _service;
        public List<JobDto> JobPosts { get; set; }

        public IndexModel(JobService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            JobPosts = await _service.GetAllJobsAsync();
        }
    }
}
