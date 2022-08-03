using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IHostEnvironment hostEnvironment, ProductService productService)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _productService = productService;
        }
        public string Index()
        {
            _logger.LogInformation("Index action");
            return "I'm index of first";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("Hi", "Xin chao cac ban");
        }

        public object Anything() => DateTime.Now;

        public IActionResult ReadMe()
        {
            var content = @"
            Xin chào các bạn,
            các bạn đang học về ASP.NET MVC

            XUANTHULAB.NET
            ";

            return Content(content, "text/plain");
        }

        public IActionResult Picture()
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "Files", "IMG_20200911_094655.jpg");
            _logger.LogError(filePath);
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/.jpg");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "iPhone X",
                    price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyển hướng đến " + url);
            return LocalRedirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                username = "Khach";
            }

            return View("Xinchao3", username);
        }
        [TempData]
        public string StatusMessage { get; set; }

        [AcceptVerbs("POST", "GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();

            if(product == null)
            {
                StatusMessage = "Sản phẩm bạn yêu cầu không có";
                return Redirect(Url.Action("Index", "Home"));
            }

            //return View(product);

            //this.ViewData["product"] = product;
            //ViewData["Title"] = product.Name;

            //return View("ViewProduct2");

            ViewBag.Product = product;
            return View("ViewProduct3");
        }

    }
}
