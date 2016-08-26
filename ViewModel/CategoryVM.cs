using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage="Please enter Category Name")]
        public string CategoryName { get; set; }
    }
}
