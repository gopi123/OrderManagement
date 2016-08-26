using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [StringLength(200)]
        public string CategoryName { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
