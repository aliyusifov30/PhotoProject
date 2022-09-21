using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoProject.Domain;
using PhotoProject.Domain.Entities;
using PhotoProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Contexts
{
    public class PhotoProjectContext : IdentityDbContext<AppUser>
    {
        public PhotoProjectContext(DbContextOptions<PhotoProjectContext> options) : base(options)
        {

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BaseFile> BaseFiles { get; set; }
    }
}
