using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoProject.Persistence.Configurations;
using PhotoProject.Persistence.Contexts;
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
            services.AddDbContext<PhotoProjectContext>(opt =>{ opt.UseSqlServer(ServiceConfiguration.ConnectionString);});
        }

    }
}
