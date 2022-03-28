using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
     public interface IRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        //ValueTask?
        Task<TEntity> GetByIdAsync(int id); 
        
        Task AddAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);

        //Find?
      //  void ActiveDeActiveAsync(bool confirmType);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


    }
}
