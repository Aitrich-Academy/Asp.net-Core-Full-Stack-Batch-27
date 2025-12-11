using EmployeeManagement.Interface;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository:IEmpRepository
    {
            private readonly AppDbContext _context;

            public EmployeeRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Employee>> GetEmployeesAsync()
            {
             return await _context.Employees.ToListAsync();
            }

            public async Task<Employee> GetEmployeeByIdAsync(int id)
            {
             return await _context.Employees.FindAsync(id);
            }
        

            public async Task AddEmployeeAsync(Employee employee)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateEmployeeAsync(Employee employee)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteEmployeeAsync(int id)
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }
        }
}
