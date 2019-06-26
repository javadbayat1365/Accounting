using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        bool Delete(T entity);
        bool DeleteByID(object ID);
        bool Update(T entity);
        bool Insert(T entity);
        T GetOneOfAll(object EntityID);
        void SaveChanges();
    }
}
