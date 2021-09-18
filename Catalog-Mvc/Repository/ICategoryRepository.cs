using System.Collections.Generic;
using System.IO.Enumeration;
using Catalog_Mvc.Models;

namespace Catalog_Mvc.Repository
{
    public interface ICategoryRepository
    {
        Category Find(int id);
        
        List<Category> GetAll();

        Category Add(Category category);

        Category Update(Category category);

        void Remove(int id);

    }
}