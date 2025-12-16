using BlazorAssessment.Helper;
using BlazorAssessment.Interface;
using BlazorAssessment.Models;
using BlazorAssessment.Repository;
using BlazorAssessment.Service;
using Microsoft.EntityFrameworkCore;

namespace BlazorAssessment.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITaskkRepository, TaskkRepository>();
            services.AddScoped<ITaskkService, TaskkService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }
    }
}
