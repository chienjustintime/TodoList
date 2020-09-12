using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entity.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        void SaveChanges();
    }
}
