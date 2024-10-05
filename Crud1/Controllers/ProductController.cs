using Crud1.Models;
using Crud1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.products.OrderByDescending(p => p.Pro_id).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
            return View(productDto);
            }

            //increase the id of the nre product added
            int maxId = (int)context.products.Max(p => p.Pro_id);


            //saving the product
            Product product = new Product()
            {
                Pro_id = maxId + 1,
                pro_name = productDto.pro_name,
                pro_price = productDto.pro_price,
                pro_description = productDto.pro_description
            };

            context.products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");

            
        }
        

      

        

    }
}
