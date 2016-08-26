using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace ViewModel
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage="Please enter Product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage="Please enter UnitPrice")]
        public decimal UnitPrice { get; set; }
        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage="Please select atleast one category")]
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }

        public string ImagePath { get; set; }

    }
}
