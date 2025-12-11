using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService
            (this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<EmployeeService>();

            return services;
        }
    }
}
