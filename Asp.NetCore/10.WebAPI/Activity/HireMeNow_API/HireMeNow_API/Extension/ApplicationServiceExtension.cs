using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.AuthUser;
using Domain.Services.Email.Interface;
using Domain.Services.Email;
using Domain.Services.Login.Interfaces;
using Domain.Services.Login;
using Domain.Services.SignUp.Interfaces;
using Domain.Services.SignUp;
using Microsoft.EntityFrameworkCore;

namespace HireMeNow_API.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("Default")));

            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            services.AddScoped<ISignupRequestRepository, SignupRequestRepository>();
            services.AddScoped<ISignupRequestService, SignupRequestService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<IAuthUserService, AuthUserService>();


            services.AddHttpContextAccessor();

            return services;
        }
    }
}
