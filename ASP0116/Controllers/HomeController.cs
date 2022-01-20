using ASP0116.BLL.Cart;
using ASP0116.BLL.Categories;
using ASP0116.BLL.Products;
using ASP0116.Entities;
using ASP0116.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartService cartService;
        static List<Product> pr = new List<Product>();


        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService, ICartService cartService)
        {
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
            this.cartService = cartService;
            foreach (var item in productService.GetAllProducts())
            {
                pr.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    BuyingPrice = item.BuyingPrice,
                    SalePrice = item.SalePrice,
                    StockAmount = item.StockAmount,
                    CategoryId = item.CategoryId
                });
            }
        }

        public IActionResult Index()
        {
            //var products = productService.GetAllProducts();
            //var product = productService.ProductGetById(2);
            //var categories = categoryService.GetAllCategories();
            //var category = categoryService.CategoryGetById(1);
            
            return View(pr);
        }

        public IActionResult Privacy()
        {
            var objectData = HttpContext.Session.GetObject<Product>("Shalvar");
            return View();
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var product = pr.FirstOrDefault(p => id == p.Id);
            cartService.AddToCart(product);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
