using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactWebApi.Interfaces.Repositories
{
   public interface IRepository<T>
    {
        IEnumerable<T> List();
       // bool Save(T entity);
        T GetByID(int id);
        bool DeleteById(int id);
        void Update();
        Task<bool> Save(T entity);
    }
}
