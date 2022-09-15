using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PhotoProject.Persistence.Configurations;
using PhotoProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PhotoProjectContext>
    {
        public PhotoProjectContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<PhotoProjectContext> builder = new();
            builder.UseSqlServer(ServiceConfiguration.ConnectionString);
            return new PhotoProjectContext(builder.Options);
        }
    }
}
