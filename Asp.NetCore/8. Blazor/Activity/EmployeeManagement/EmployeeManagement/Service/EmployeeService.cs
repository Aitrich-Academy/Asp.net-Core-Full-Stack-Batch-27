using EmployeeManagement.Interface;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Service
{
    public class EmployeeService:IEmpService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await employeeRepository.GetEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await employeeRepository.GetEmployeeByIdAsync(id);
        }


        public async Task AddEmployeeAsync(Employee employee)
        {
            await employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
           await employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
