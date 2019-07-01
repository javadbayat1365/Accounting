using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{

    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T,bool>> where=null);
        bool Delete(T entity);
        bool DeleteByID(object ID);
        bool Update(T entity);
        bool Insert(T entity);
        T GetById(object EntityID);
    }
}
