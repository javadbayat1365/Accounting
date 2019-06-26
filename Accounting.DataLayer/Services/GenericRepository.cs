using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private Businness_DBEntities db;
        private DbSet<T> table;
        public GenericRepository(Businness_DBEntities DB)
        {
            db = DB;
            table = db.Set<T>();
        }
        public bool Delete(T entity)
        {
            try
            {
                
                table.Remove(entity);
                //db.Entry(table).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
        }

        public bool DeleteByID(object ID)
        {
            T entity = table.Find(ID);
            table.Remove(entity);
            return true;
        }
        public IEnumerable<T> GetAll()
        {
           var sel = table.ToList();
            return sel;


        }

        public T GetOneOfAll(object EntityID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
