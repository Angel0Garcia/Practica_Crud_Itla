using Crud1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud1.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext context;
        public ReceiptController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var receipts = context.receipts.ToList();
            return View(receipts);
        }
    }
}
