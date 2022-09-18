using Microsoft.Extensions.DependencyInjection;
using PhotoProject.Application.Abstractions.Services.AppUserServices;
using PhotoProject.Application.Abstractions.Services.TokenServices;
using PhotoProject.Application.DTOs.JwtDTOs;
using PhotoProject.Infrastructure.Configurations;
using PhotoProject.Infrastructure.Services.TokenServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Infrastructure
{
    public static class SevriceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.Configure<JwtDto>(ServiceConfiguration.GetConfigurationSection("JWT"));
        }

    }
}
