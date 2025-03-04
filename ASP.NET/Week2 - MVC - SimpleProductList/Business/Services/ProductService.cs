using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ProductService : IProductService
{
    private static List<Product> products = new List<Product>
    {
        new Product {
            Id = Guid.NewGuid(),
            Name = "Produkt 1",
            Img = "images/produkt1.png",
            Price = 100
        },
        new Product {
            Id = Guid.NewGuid(),
            Name = "Produkt 2",
            Img = "images/produkt2.png",
            Price = 200
        },
        new Product {
            Id = Guid.NewGuid(),
            Name = "Produkt 3",
            Img = "images/produkt3.png",
            Price = 300
        }
    };

    public IEnumerable<Product> GetProducts()
    {
        return products;
    }

}
