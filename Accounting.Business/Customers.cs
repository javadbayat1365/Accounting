using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Business
{
   public class Customers : IDisposable
    {
       private UnitOfWork _uow;
        public Customers()
        {
            _uow = new UnitOfWork();
        }
        public List<ListCustomersViewModel> Get(Expression<Func<DataLayer.Customers,bool>> where=null)
        {
            return _uow.Customers.Get(where)
                .Select(s => new ListCustomersViewModel() {
                    Address = s.Address,
                    FullName = s.FullName,
                    Mobile = s.Mobile,
                    ID = s.ID
                }).ToList();
        }
        //public ListCustomersViewModel GetById(long id)
        //{
        //   return _uow.Customers.GetById(id);
        //}
        public void DeleteByID(long ID)
        {
            _uow.Customers.DeleteByID(ID);
        }
        public void Insert(DataLayer.Customers entity)
        {
            _uow.Customers.Insert(entity);
        }
        public void Save()
        {
            _uow.Save();
        }
        public void Update(DataLayer.Customers entity)
        {
            _uow.Customers.Update(entity);
        }
        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
