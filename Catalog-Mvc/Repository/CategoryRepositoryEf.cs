using System.Collections.Generic;
using System.Linq;
using Catalog_Mvc.Data;
using Catalog_Mvc.Models;

namespace Catalog_Mvc.Repository
{
    public class CategoryRepositoryEf : ICategoryRepository
    {

        private readonly ApplicationDbContext _db;


        public CategoryRepositoryEf(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Find(int id)
        {
            return _db.Category.FirstOrDefault(u => u.id == id);
        }

        public List<Category> GetAll()
        {
            return _db.Category.ToList();
        }

        public Category Add(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _db.Category.Update(category);
            _db.SaveChanges();
            return category;
        }

        public void Remove(int id)
        {
           Category category = _db.Category.FirstOrDefault(u => u.id == id);
           _db.Category.Remove(category);
           _db.SaveChanges();
           return;

        }
    }
}