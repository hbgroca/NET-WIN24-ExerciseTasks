using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class _ProductsModel(IProductService productService) : PageModel
    {
        private readonly IProductService _productService = productService;

        public List<Product> Products { get; set; } = [];

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}
