using ASP0116.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB.Repositories.Products.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        int Update(Product product);
        Product Add(Product product);
        void Delete(int id);
    }
}
