using Microsoft.EntityFrameworkCore;
using RazorTest.Helper;
using RazorTest.Interface;
using RazorTest.Model;
using RazorTest.Repository;
using RazorTest.Service;

namespace RazorTest.Extension
{
    public static class AppServiceExtension
    {

        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IBookService,BookService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));


            return services;

        }
    }
}
