using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private Businness_DBEntities db ;
        private ICustomers _ICustomers;
        private IAccounting _IAccounting;
        public UnitOfWork()
        {
            if (db == null)
            {
                ////دیتابیس با هر تغییر در مودل به صورت اتوماتیک حذف و دوباره ساخته میشود
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
                ////دیتابیس در مدل کد فرست با اجرای هر بار کانتکس یطور اتوماتیک حذف و ساخته می شود
                //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
                ////تنظیمات بالا برای حذف و دوباره ساخته شدن دیتابیس را غیر فعال میکند
                //Database.SetInitializer<Context>(null);

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
        public IAccounting Accounting {
            get {
                if (_IAccounting == null)
                {
                    _IAccounting = new Services.Accounting(db);
                }
                return _IAccounting;
            } }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            
            db.Dispose();
        }
    }
}
