using ASP0116.Entities;
using ASP0116.FakeDB.Repositories.Products.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.BLL.Cart
{
    public interface ICartService
    {
        void AddToCart(Product product);
    }
    public class CartService : ICartService
    {
        private readonly IProductRepository productRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartService(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.productRepository = productRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void AddToCart(Product product)
        {
            httpContextAccessor.HttpContext.Session.SetObject<Product>(product.Name, product);
            //var cart = httpContextAccessor.HttpContext.Session.GetObject<Product>(product.Name);

        }

    }
}
