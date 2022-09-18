using Microsoft.EntityFrameworkCore;
using PhotoProject.Application.Repositories;
using PhotoProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
    {

        private readonly PhotoProjectContext _context;

        public WriteRepository(PhotoProjectContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();
        
        public void Delete(TEntity entity)
            => _context.Remove(entity);

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            return entityEntry.Entity;
        }
        public async Task InsertRangeAsync(ICollection<TEntity> entities)
            => await Table.AddRangeAsync(entities);
    }
}
