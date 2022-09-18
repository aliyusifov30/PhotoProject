using Microsoft.EntityFrameworkCore;
using PhotoProject.Application.Repositories;
using PhotoProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    {

        private readonly PhotoProjectContext _context;
        public ReadRepository(PhotoProjectContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp, bool tracking = true)
            => await IsTracking(tracking).Where(exp).ToListAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, bool tracking = true)
            => await IsTracking(tracking).FirstOrDefaultAsync(exp);

        public async Task<TEntity> GetByIdAsync(int id, bool tracking = true)
            => await Table.FindAsync(id);

        private IQueryable<TEntity> IsTracking(bool tracking)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

    }
}
