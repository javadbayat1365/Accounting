﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public interface ICustomers : IGenericRepository<Customers>
    {
        IEnumerable<Customers> GetCustomersByFilter(string str);
    }
}
