﻿using Accounting.DataLayer.Repositories;
using Accounting.Utilities.Convertor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class Customers : GenericRepository<DataLayer.Customers>,ICustomers
    {
        private Businness_DBEntities db;
        public Customers(Businness_DBEntities DB):base(DB)
        {
            db = DB;
        }

        public new bool Delete(DataLayer.Customers entity)
        {
           return base.Delete(entity);
        }
        public new bool DeleteByID(object ID)
        {
            return base.DeleteByID(ID);
        }

        public new IEnumerable<DataLayer.Customers> GetAll()
        {
            var sel = base.Get();
            foreach (var item in sel)
            {

               item.Mobile = item.Mobile.RialFormat() +" "+ DateTime.Now.ToShamsi();
            }
            return sel;
        }

        public IEnumerable<DataLayer.Customers> GetCustomersByFilter(string str)
        {
            return db.Customers.Where(w => w.Email.Contains(str) || w.FullName.Contains(str) || w.Mobile.Contains(str)).ToList();
        }

        public DataLayer.Customers GetOneOfAll(object EntityID)
        {
           return base.GetById(EntityID);
        }

        public bool Insert(DataLayer.Customers entity)
        {
           return base.Insert(entity);
        }

        public bool Update(DataLayer.Customers entity)
        {
            return base.Update(entity);
        }
    }
}
