using MyApp.Dtos;
using MyApp.Models;

namespace MyApp.Interfaces
{
    public interface IProductFactory
    {
        Product Create(ProductDto product);
    }
}