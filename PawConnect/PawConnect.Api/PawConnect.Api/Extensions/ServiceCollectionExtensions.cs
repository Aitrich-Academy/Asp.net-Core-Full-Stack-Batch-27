using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PawConnect.Api.API.Pets.Helper;
using PawConnect.Api.API.Users.Helper;
using PawConnect.Domain.Data;
using PawConnect.Domain.Repositories;
using PawConnect.Domain.Repositories.Interfaces;
using PawConnect.Domain.Services;
using PawConnect.Domain.Services.Interfaces;

namespace PawConnect.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPawConnectServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 1️⃣ DbContext (Domain DbContext)
            services.AddDbContext<PawConnectDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

         
            services.AddAutoMapper(typeof(PetMappingProfile).Assembly);

            // 3️⃣ Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IAdoptionRequestRepository, AdoptionRequestRepository>();
            services.AddScoped<IFavoritePetRepository, FavoritePetRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IShelterRepository, ShelterRepository>();
            services.AddScoped<IPetCareServiceRepository, PetCareServiceRepository>();
            services.AddScoped<ISurrenderRequestRepository, SurrenderRequestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            // 4️⃣ Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IAdoptionService, AdoptionService>();
            services.AddScoped<IFavoritePetService, FavoritePetService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IShelterService, ShelterService>();
            services.AddScoped<IPetCareServiceService, PetCareServiceService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ISurrenderService, SurrenderService>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
