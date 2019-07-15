using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private Businness_DBEntities _db;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(Businness_DBEntities DB)
        {
            _db = DB;
            _dbSet = _db.Set<TEntity>();
        }
        public virtual bool Delete(TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
        }

        public virtual bool DeleteByID(object ID)
        {
            try
            {
                TEntity entity = GetById(ID);
                return Delete(entity);
            }
            catch (Exception w)
            {
                return false;
            }
            
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                if (where != null)
                {
                    query = query.Where(where);
                }
                return query.ToList();
            }
            catch (Exception w)
            {
                return null;
            }
           
        }

        public virtual TEntity GetById(object EntityID)
        {
            
            try
            {
                TEntity entity = _dbSet.Find(EntityID);
                return entity;
            }
            catch (Exception w)
            {
                return null;
            }
            
        }

        public virtual bool Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
            
        }

        public virtual bool Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(_dbSet).State = EntityState.Modified;
            return true;
        }
    }
}
