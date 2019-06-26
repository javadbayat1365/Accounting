using Accounting.DataLayer;
using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Businness_DBEntities DB = new Businness_DBEntities();
            ICustomers customers = new Accounting.DataLayer.Services.Customers(DB);
            customers.DeleteByID(1);
            customers.SaveChanges();
        }
    }
}
