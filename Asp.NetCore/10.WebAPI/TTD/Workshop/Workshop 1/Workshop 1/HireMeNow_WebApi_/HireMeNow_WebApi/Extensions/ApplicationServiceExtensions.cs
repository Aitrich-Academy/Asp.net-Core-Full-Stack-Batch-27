using Domain;

using Microsoft.EntityFrameworkCore;
using Domain.Service;
using MailKit;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Authuser;

using Domain.Models;

using Domain.Service.Job.Interfaces;
using Domain.Service.Job;

using Domain.Service.Login.Interfaces;
using Domain.Service.Login;
using Domain.Service.Job;
using Domain.Service.Job.Interfaces;

using Domain.Service.Profile;

using Domain.Service.Profile.Interface;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Admin;
using Domain.Service.User.Interface;
using Domain.Service.User;



namespace HireMeNow_WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
       
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService,AuthUserService>(); 
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IJobServices, JobServices>();
			services.AddScoped<IAuthUserService, AuthUserService>();
			services.AddHttpContextAccessor();
            services.AddScoped<IJobSeekerProfileService, ProfileService>();
            services.AddScoped<IJobSeekerProfileRepository, ProfileRepository>();
			services.AddScoped<IJobRepository,JobRepository>();
            services.AddScoped<IJobServices, JobServices>();     
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserService,UserServices>();



            return services;
        }
    }
}
