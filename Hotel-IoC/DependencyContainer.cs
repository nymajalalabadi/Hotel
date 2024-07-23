using Hotel_Application.Services.Implementation;
using Hotel_Application.Services.Interface;
using Hotel_DataLayer.Repositories;
using Hotel_Domain.InterFaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_IoC
{
    public class DependencyContainer
    {
        public static void RejosterService(IServiceCollection services)
        {
            #region service

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBanerService, BanerService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IAdvantageService, AdvantageService>();

            #endregion

            #region repository

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBanerRepository, BanerRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IAdvantageRepository, AdvantageRepository>();

            #endregion
        }
    }
}
