using System;
using System.Collections;
using System.Collections.Generic;
using Catalog_Mvc.Data;
using Catalog_Mvc.Models;
using Catalog_Mvc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Mvc.Controllers
{
    public class CategoryController : Controller
    {

        // private readonly ApplicationDbContext _db;
        private readonly ICategoryRepository _categoryRepository;

        
        
       // public CategoryController(ApplicationDbContext db)
       //  {
       //      _db = db;
       //  } 
       public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        } 
        
        
        // GET
        public IActionResult Index()
        {
            // IEnumerable<Category> objList = _db.Category;
            // return View(objList);
            return View(_categoryRepository.GetAll());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(obj);
                return RedirectToAction("Index");

            }


            return View(obj);
        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _categoryRepository.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(obj);
                return RedirectToAction("Index");

            }


            return View(obj);
        }
        
        
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obj = _categoryRepository.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _categoryRepository.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _categoryRepository.Remove(id);
            return RedirectToAction("Index");
            
        }

        
        



    }
}