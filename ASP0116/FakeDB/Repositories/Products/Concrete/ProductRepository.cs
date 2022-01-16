using ASP0116.Entities;
using ASP0116.FakeDB.Repositories.Products.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB.Repositories.Products.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public Product Add(Product product)
        {
            SeedData.Products.Add(product);
            return product;
        }

        public void Delete(int id)
        {
            var product = SeedData.Products.FirstOrDefault(i => i.Id == id);
            SeedData.Products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return SeedData.Products;
        }

        public Product GetById(int id)
        {
            return SeedData.Products.FirstOrDefault(i => i.Id == id);
        }

        public int Update(Product product)
        {
            if (product.Id <= 0) throw new ArgumentNullException();
            var currentProduct = SeedData.Products.FirstOrDefault(i => i.Id == product.Id);
            SeedData.Products.Remove(currentProduct);
            SeedData.Products.Add(product);
            return product.Id;
        }
    }
}
