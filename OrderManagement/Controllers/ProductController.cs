
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DAL;
using ViewModel;
namespace OrderManagement.Controllers
{
    public class ProductController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        // GET: Product
        public ActionResult Index()
        {
            List<ProductVM> _modelList = new List<ProductVM>();
            try
            {
                List<Product> _dbList = _db.Products.ToList();
                foreach (var dbItem in _dbList)
                {
                    ProductVM _model = new ProductVM();
                    _model.ProductName = dbItem.ProductName;
                    _model.UnitPrice = dbItem.UnitPrice;

                    _modelList.Add(_model);
                }

            }
            catch (Exception ex)
            {
                _modelList = null;
            }
            return View(_modelList);
        }
    }
}