using Microsoft.EntityFrameworkCore;
using PhotoProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Contexts
{
    public class PhotoProjectContext : DbContext
    {
        public PhotoProjectContext(DbContextOptions<PhotoProjectContext> options) : base(options)
        {

        }
        public DbSet<Tag> Tags { get; set; }
    }
}
