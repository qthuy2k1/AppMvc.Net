using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            var products = productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}
