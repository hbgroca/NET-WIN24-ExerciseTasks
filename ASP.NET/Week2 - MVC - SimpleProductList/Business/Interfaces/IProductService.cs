using Business.Models;

namespace Business.Interfaces;
public interface IProductService
{
    IEnumerable<Product> GetProducts();
}