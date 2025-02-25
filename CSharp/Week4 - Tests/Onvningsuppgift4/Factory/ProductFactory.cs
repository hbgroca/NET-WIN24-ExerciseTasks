
using MyApp.Dtos;
using MyApp.Interfaces;
using MyApp.Models;

namespace MyApp.Factory;

public class ProductFactory : IProductFactory
{
    public Product Create(ProductDto product)
    {
        try
        {
            Product x = new Product();
            x.Id = product.Id;
            x.Name = product.Name;
            x.Price = product.Price;
            return x;
        }
        catch
        {
            return null!;
        }
    }
}
