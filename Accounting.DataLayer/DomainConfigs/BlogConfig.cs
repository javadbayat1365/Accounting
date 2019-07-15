using DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.DomainConfigs
{
   public class BlogConfig : EntityTypeConfiguration<Blog>
    {
        public BlogConfig()
        {
            this.Property(x => x.AuthorName).IsRequired();
            this.HasKey(x => x.BlogId);
            this.Property(x => x.Title).HasMaxLength(100);
            this.Property(x => x.RowVersion).HasColumnType("Timestamp");
          
        }
    }
}
