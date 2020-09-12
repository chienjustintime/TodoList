using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entity.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IGenericRepository<T> Repository<T>() where T : class;
    }
}
