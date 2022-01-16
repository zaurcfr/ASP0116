using ASP0116.BLL.Categories.Models;
using ASP0116.Entities;
using ASP0116.FakeDB.Repositories.Categories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.BLL.Categories
{
    public interface ICategoryService
    {
        List<GetAllCategoriesResponse> GetAllCategories();
        int Add(AddCategoryRequest request);
        int Update(UpdateCategoryRequest request);
        void Delete(int id);
        CategoryGetByIdResponse CategoryGetById(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public int Add(AddCategoryRequest request)
        {
            var category = new Category
            {
                Id = categoryRepository.GetAll().Count + 1,
                Name = request.Name
            };
            return category.Id;
        }

        public CategoryGetByIdResponse CategoryGetById(int id)
        {
            var category = (from c in categoryRepository.GetAll()
                           select new CategoryGetByIdResponse
                           {
                               Id = c.Id,
                               Name = c.Name
                           }).FirstOrDefault(i => i.Id == id);
            return category;
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public List<GetAllCategoriesResponse> GetAllCategories()
        {
            var categories = categoryRepository.GetAll().Select(i => new GetAllCategoriesResponse
            {
                Id = i.Id,
                Name = i.Name
            });
            return categories.ToList();
        }

        public int Update(UpdateCategoryRequest request)
        {
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name
            };
            categoryRepository.Update(category);
            return category.Id;
        }
    }
}
