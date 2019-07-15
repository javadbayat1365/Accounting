using Accounting.DataLayer.Repositories;
using Accounting.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class Accounting : GenericRepository<DataLayer.Accounting>, IAccounting
    {
        private Businness_DBEntities _db;
        public Accounting(Businness_DBEntities DB):base(DB)
        {
            _db = DB;
        }
        public bool Delete(Accounting entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DataLayer.Accounting entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByID(object ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accounting> Get(Expression<Func<Accounting, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomersViewModel> Get(Expression<Func<DataLayer.Accounting, bool>> where = null)
        {
            return base.Get(where).Select(s => new ListCustomersViewModel() {
                 Address = s.Description,
                 FullName = s.CustomerId.ToString(),
                 Mobile = s.DateTime.ToString()
            });
        }

        public Accounting GetById(object EntityID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Accounting entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DataLayer.Accounting entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Accounting entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DataLayer.Accounting entity)
        {
            throw new NotImplementedException();
        }

        DataLayer.Accounting IGenericRepository<DataLayer.Accounting>.GetById(object EntityID)
        {
            throw new NotImplementedException();
        }
    }
}
