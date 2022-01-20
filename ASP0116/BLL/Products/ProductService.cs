using ASP0116.BLL.Products.Models;
using ASP0116.Entities;
using ASP0116.FakeDB.Repositories.Categories.Abstract;
using ASP0116.FakeDB.Repositories.Products.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.BLL.Products
{
    public interface IProductService
    {
        List<GetAllProductsResponse> GetAllProducts();
        int Add(AddProductRequest request);
        int Update(UpdateProductRequest request);
        void Delete(int id);
        ProductGetByIdResponse ProductGetById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Add(AddProductRequest request)
        {
            var product = new Product
            {
                Id = productRepository.GetAll().Count + 1,
                Name = request.Name,
                BuyingPrice = request.BuyingPrice,
                SalePrice = request.SalePrice,
                StockAmount = request.StockAmount,
                CategoryId = request.CategoryId
            };
            productRepository.Add(product);
            return product.Id;
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public List<GetAllProductsResponse> GetAllProducts()
        {
            var products = productRepository.GetAll().Select(i => new GetAllProductsResponse
            {
                Id = i.Id,
                Name = i.Name,
                BuyingPrice = i.BuyingPrice,
                SalePrice = i.SalePrice,
                StockAmount = i.StockAmount,
                CategoryId = i.CategoryId
            });
            return products.ToList();
        }

        public ProductGetByIdResponse ProductGetById(int id)
        {
            //var product = productRepository.GetById(id);
            //ProductGetByIdResponse response = new ProductGetByIdResponse
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    BuyingPrice = product.BuyingPrice,
            //    SalePrice = product.SalePrice,
            //    StockAmount = product.StockAmount
            //};

            var product = (from p in productRepository.GetAll()
                           join c in categoryRepository.GetAll()
                           on p.CategoryId equals c.Id
                           //into leftProducts
                           //from pp in leftProducts.DefaultIfEmpty() -- left join
                           select new ProductGetByIdResponse
                           {
                               Id = p.Id,
                               Name = p.Name,
                               BuyingPrice = p.BuyingPrice,
                               SalePrice = p.SalePrice,
                               StockAmount = p.StockAmount,
                               CategoryName = c.Name
                           }).FirstOrDefault(i => i.Id == id);
            return product;
        }

        public int Update(UpdateProductRequest request)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                BuyingPrice = request.BuyingPrice,
                SalePrice = request.SalePrice,
                StockAmount = request.StockAmount,
                CategoryId = request.CategoryId
            };
            productRepository.Update(product);
            return product.Id;
        }
    }
}
