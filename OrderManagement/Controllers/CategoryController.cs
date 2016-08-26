using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DAL;
using ViewModel;
using System.Data.Entity;
namespace OrderManagement.Controllers
{
    public class CategoryController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryVM> _modelList = new List<CategoryVM>();
            List<Category> _objList = new List<Category>();
            try
            {
                _objList = _db.Categoires.ToList();
                foreach (var obj in _objList)
                {
                    CategoryVM _model = new CategoryVM();
                    _model.CategoryId = obj.CategoryId;
                    _model.CategoryName = obj.CategoryName;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category _dbCategory = new Category();
                    _dbCategory.CategoryName = model.CategoryName;
                    _dbCategory.TransactionDate = DateTime.Now.Date;

                    _db.Categoires.Add(_dbCategory);
                    int i = _db.SaveChanges();
                    if (i > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Category _dbCategory = _db.Categoires.Find(id);
                if (_dbCategory != null)
                {
                    CategoryVM _modelCategory = new CategoryVM();
                    _modelCategory.CategoryName = _dbCategory.CategoryName;
                    _modelCategory.CategoryId = _dbCategory.CategoryId;

                    return View(_modelCategory);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Edit(CategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category _dbCategory = _db.Categoires.Find(model.CategoryId);
                    if (_dbCategory != null)
                    {
                        _dbCategory.CategoryName = model.CategoryName;
                        _dbCategory.TransactionDate = DateTime.Now;

                        _db.Entry(_dbCategory).State = EntityState.Modified;
                        int i = _db.SaveChanges();
                        if (i > 0)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Edit", new { id = model.CategoryId });
                        }
                    }
                }

                return RedirectToAction("Edit", new { id = model.CategoryId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", new { id = model.CategoryId });
            }
        }

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category _dbCategory = _db.Categoires.Find(id);
                if (_dbCategory != null)
                {
                    _db.Entry(_dbCategory).State = EntityState.Deleted;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    }
}