using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorEmployeeManagement.Models;

namespace RazorEmployeeManagement.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> EmployeeList { get; set; }

        /*OnGetAsync method is fetching a list of employees asynchronously,
         which is a good approach for performance.
        In C#, Task represents an asynchronous operation. 
        It is part of the System.Threading.
        Tasks namespace and allows methods to run without blocking the main thread.*/
        public async Task OnGetAsync()
        {
            EmployeeList = await _context.Employees.ToListAsync();
        }
    }
}
