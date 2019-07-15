using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    [Table("tblPost")]
   public class Post
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("Blog")]
        public virtual Blog Blog{ get; set; }

    }
}
