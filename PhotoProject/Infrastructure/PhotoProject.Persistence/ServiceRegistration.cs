using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoProject.Application.Abstractions.Services.AppUserServices;
using PhotoProject.Application.Repositories.TagRepositories;
using PhotoProject.Domain.Entities.Identity;
using PhotoProject.Persistence.Configurations;
using PhotoProject.Persistence.Contexts;
using PhotoProject.Persistence.Repositories.TagRepositories;
using PhotoProject.Persistence.Services.AppUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<PhotoProjectContext>(opt => { opt.UseSqlServer(ServiceConfiguration.ConnectionString); });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<PhotoProjectContext>();

            services.AddScoped<ITagWriteRepository, TagWriteRepository>();
            services.AddScoped<ITagReadRepository, TagReadRepository>();

            services.AddScoped<IAppUserService, AppUserService>();
        }
    }
}
