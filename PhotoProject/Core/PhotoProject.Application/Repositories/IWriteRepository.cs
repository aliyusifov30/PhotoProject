using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        Task<TEntity> InsertAsync(TEntity entity);
        Task InsertRangeAsync(ICollection<TEntity> entities);
        Task<int> CommitAsync();

        void Delete(TEntity entity);
    }
}
