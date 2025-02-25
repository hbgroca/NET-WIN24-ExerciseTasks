using MyApp.Dtos;
using MyApp.Factory;
using MyApp.Interfaces;
using MyApp.Models;

namespace MyApp.Services;

public class ProductServices : IProductService
{
    public List<Product> _products = [];
    private readonly IProductFactory _productFactory;

    public ProductServices(IProductFactory productFactory)
    {
        _productFactory = productFactory;
    }

    public void AddProduct(ProductDto productDto)
    {
        Product product = _productFactory.Create(productDto);
        if (product != null) {
            _products.Add(product);
        }
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        try
        {
            Product Product = _products[id];
            return Product;
        }
        catch
        {
            throw new Exception("Product not found");
        }
    }
}
