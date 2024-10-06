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
            System.Linq.Expressions.Expression<Func<Product, int>> keySelector = p => p.Pro_id;
            var products = context.products.OrderByDescending(keySelector).ToList();
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

            //increase the id of the product added
            int maxId = context.products.Max(p => p.Pro_id);


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

        public IActionResult Edit(int id)
        { 
            var product = context.products.Find(id);

            if (product == null) 
            {
                return RedirectToAction("Index", "Product");
            }

            var produtDto = new ProductDto()
            {
                pro_name=product.pro_name,
                pro_price=product.pro_price,
                pro_description=product.pro_description
            };

            ViewData["ProductId"] = product.Pro_id;


            return View(produtDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = context.products.Find(id);

            if (product == null) 
            {
                return RedirectToAction("Index", "Product");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Pro_id;
                return View(productDto);
            }

            product.pro_name = productDto.pro_name;
            product.pro_price = productDto.pro_price;
            product.pro_description = productDto.pro_description;

            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public ActionResult Delete(int id)
        {
            var product = context.products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            context.products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }









    }
}
