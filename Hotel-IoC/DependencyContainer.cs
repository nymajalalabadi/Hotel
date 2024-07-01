﻿using Hotel_Application.Services.Implementation;
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

            #endregion

            #region repository

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
