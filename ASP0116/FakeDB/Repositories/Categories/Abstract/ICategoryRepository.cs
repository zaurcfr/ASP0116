using ASP0116.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB.Repositories.Categories.Abstract
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<Category> GetAll();
        Category Add(Category category);
        int Update(Category category);
        void Delete(int id);

    }
}
