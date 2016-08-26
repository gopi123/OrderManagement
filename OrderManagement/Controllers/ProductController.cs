
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

        public class clsCategoryList
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
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

        public ActionResult Create()
        {
            try
            {
                List<clsCategoryList> _categoryList=GetCategoryList();               

                ProductVM _model = new ProductVM();
                _model.CategoryList = new SelectList(_categoryList, "Id", "Name");

                return View(_model);
               
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(ProductVM model)
        {
            try
            {
                Product _dbProduct = new Product();
                _dbProduct.ProductName = model.ProductName;
                _dbProduct.UnitPrice = model.UnitPrice;
                _dbProduct.TransactionDate = DateTime.Now;
                _dbProduct.CategoryId = model.CategoryId;

                //_db.Products.Add(_dbProduct);
                //_db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public List<clsCategoryList> GetCategoryList()
        {
            List<clsCategoryList> _clsCategory = new List<clsCategoryList>();
            try
            {
                _clsCategory = _db.Categoires
                              .Select(c => new clsCategoryList
                              {
                                  Id = c.CategoryId,
                                  Name = c.CategoryName
                              }).ToList();

            }
            catch (Exception ex)
            {
                _clsCategory = null;
            }
            return _clsCategory;
        }
    }
}