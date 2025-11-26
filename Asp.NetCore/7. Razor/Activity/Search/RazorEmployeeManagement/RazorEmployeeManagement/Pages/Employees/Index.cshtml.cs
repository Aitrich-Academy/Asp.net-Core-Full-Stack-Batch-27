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

        //public IList<Employee> EmployeeList { get; set; }

        /*OnGetAsync method is fetching a list of employees asynchronously,
         which is a good approach for performance.
        In C#, Task represents an asynchronous operation. 
        It is part of the System.Threading.
        Tasks namespace and allows methods to run without blocking the main thread.*/
        //public async Task OnGetAsync()
        //{
        //    EmployeeList = await _context.Employees.ToListAsync();
        //}
        public IList<Employee> EmployeeList { get; set; } = new List<Employee>();
        /*BindProperty: Binds query string data to this property.

        SupportsGet = true: Allows binding during GET requests (like from a search form).

        SearchTerm: Holds the text the user types into the search box.
         */

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; } // <-- Added search term binding

        public async Task OnGetAsync()
        {
            var query = _context.Employees.AsQueryable();//Creates a queryable object to build filtering logic dynamically.

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(e =>
                    e.Name.Contains(SearchTerm) ||
                    e.Position.Contains(SearchTerm));
            }

            EmployeeList = await query.ToListAsync();
        }
    }
}
