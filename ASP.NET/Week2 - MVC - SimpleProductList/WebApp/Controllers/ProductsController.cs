using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductsController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        [Route("produkter")]
        public IActionResult ProductsList()
        {
            ViewData["Title"] = "Produkter";
            var products = _productService.GetProducts();

            return View(products);
        }
    }
}
