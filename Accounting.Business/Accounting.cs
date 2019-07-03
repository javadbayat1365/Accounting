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
   public class Accounting
    {
        UnitOfWork uow = new UnitOfWork();
        public List<ListCustomersViewModel> Get(Expression<Func<DataLayer.Accounting, bool>> where = null)
        {
            var result = uow.Accounting.Get(where).Select(s => new ListCustomersViewModel() {
                 Address = s.Amount.ToString(),
                 FullName = s.DateTime.ToString(),
                 Mobile = s.Description
            });
            return result.ToList();
        }

    }
}
