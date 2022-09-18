using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetByIdAsync(int id, bool tracking = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, bool tracking = true);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> exp, bool tracking = true);
    }
}
