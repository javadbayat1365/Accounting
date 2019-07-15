using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Models
{
    [Table("tblBlog")]
   public class Blog
    {
        /// <summary>
        /// if we use Id or EntityId for key name ,do not need to use [Key] for the property
        /// </summary>
        [Key]
        public int BlogId { get; set; }
        [MaxLength(100,ErrorMessage ="طول عنوان نمیتواند بزرگتر از 100 باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage ="نام نویسنده حتما باید پر شود")]
        public string AuthorName { get; set; }
        
        public List<Post> Posts { get; set; }

        /// <summary>
        ///  this property will not map on DB
        /// </summary>
        //[NotMapped]
        public int RowVersion { get; set; }
    }
}
