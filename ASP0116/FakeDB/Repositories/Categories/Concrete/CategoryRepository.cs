using ASP0116.Entities;
using ASP0116.FakeDB.Repositories.Categories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB.Repositories.Categories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Add(Category category)
        {
            SeedData.Categories.Add(category);
            return category;
        }

        public void Delete(int id)
        {
            var category = SeedData.Categories.FirstOrDefault(i => i.Id == id);
        }

        public List<Category> GetAll()
        {
            return SeedData.Categories;
        }

        public Category GetById(int id)
        {
            return SeedData.Categories.FirstOrDefault(i => i.Id == id);
        }

        public int Update(Category category)
        {
            if (category.Id <= 0) throw new ArgumentNullException();
            var currentCategory = SeedData.Categories.FirstOrDefault(i => i.Id == category.Id);
            SeedData.Categories.Remove(currentCategory);
            SeedData.Categories.Add(category);
            return category.Id;
        }
    }
}
