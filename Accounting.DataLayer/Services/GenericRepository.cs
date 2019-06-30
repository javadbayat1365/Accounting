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
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
        }

        public bool DeleteByID(object ID)
        {
            try
            {
                T entity = table.Find(ID);
                return Delete(entity);
            }
            catch (Exception w)
            {
                return false;
            }
            
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                var sel = table.ToList();
                return sel;
            }
            catch (Exception w)
            {
                return null;
            }
           
        }

        public T GetOneOfAll(object EntityID)
        {
            try
            {
                T entity = table.Find(EntityID);
                return entity;
            }
            catch (Exception w)
            {
                return null;
            }
            
        }

        public bool Insert(T entity)
        {
            try
            {
                table.Add(entity);
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
            
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
