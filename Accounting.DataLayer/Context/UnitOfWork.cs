using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private Businness_DBEntities db;
        private ICustomers _ICustomers;
        public UnitOfWork()
        {
            if (db == null)
            {
                db = new Businness_DBEntities();
            }
        }
        public ICustomers Customers
        {
            get
            {
                if (_ICustomers == null)
                {
                    _ICustomers = new Services.Customers(db);
                }
                return _ICustomers;
            }
        }



        public void Dispose()
        {
            db.Dispose();
        }
    }
}
