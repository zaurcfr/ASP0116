using ASP0116.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB
{
    public static class SeedData
    {
        public static List<Product> Products { get; set; }
        public static List<Category> Categories { get; set; }

        public static List<Product> FillProducts()
        {
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Shalvar", SalePrice = 56.5M, BuyingPrice = 51.5M, StockAmount = 50, CategoryId = 1 },
                new Product { Id = 2, Name = "Kitab", SalePrice = 25.5M, BuyingPrice = 22.5M, StockAmount = 35, CategoryId = 2 },
                new Product { Id = 3, Name = "Turnik", SalePrice = 15.5M, BuyingPrice = 9.5M, StockAmount = 21, CategoryId = 3 },
                new Product { Id = 4, Name = "Komputer", SalePrice = 546.5M, BuyingPrice = 511.5M, StockAmount = 10, CategoryId = 4 }
            };
            return Products;
        }

        public static List<Category> FillCategories()
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Paltar" },
                new Category { Id = 2, Name = "Ofis Levazimatlari" },
                new Category { Id = 3, Name = "Idman Mallari" },
                new Category { Id = 4, Name = "Elektronika" },
            };
            return Categories;
        }
    }
}
