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
        public IActionResult Create()
        {

        }

    }
}
