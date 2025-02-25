

using MyApp.Dtos;
using MyApp.Models;

namespace MyApp.Interfaces;

public interface IProductService
{
    void AddProduct(ProductDto productDto);
    Product GetProductById(int id);
    List<Product> GetAllProducts();
}
