using DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.DomainConfigs
{
   public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            this.ToTable("tblPost");
            this.HasKey(x => x.Id);
            this.Property(x => x.Title).HasMaxLength(100);
            this.Property(x => x.Title).HasColumnType("nvarchar");
        }
    }
}
