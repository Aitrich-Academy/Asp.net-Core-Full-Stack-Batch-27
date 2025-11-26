using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorEmployeeManagement.Models;
using System.Threading.Tasks;

namespace RazorEmployeeManagement.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employeeToUpdate = await _context.Employees.FindAsync(Employee.Id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            // Manually update properties
            employeeToUpdate.Name = Employee.Name;
            employeeToUpdate.Position = Employee.Position;
            employeeToUpdate.Salary = Employee.Salary;
            employeeToUpdate.Department = Employee.Department;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}

