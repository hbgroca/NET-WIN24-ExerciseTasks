using Business.Models;

namespace Business.Interfaces;
public interface IProductService
{
    List<Product> GetProducts();
}