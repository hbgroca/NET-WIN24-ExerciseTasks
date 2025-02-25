using Moq;
using MyApp.Dtos;
using MyApp.Factory;
using MyApp.Interfaces;
using MyApp.Models;
using MyApp.Services;
namespace MyApp_Test.Services;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_ShouldReturnTrueIfSuccessfull()
    {
        //arrange
        IProductFactory productFactory = new ProductFactory();
        ProductServices products = new ProductServices(productFactory);
        ProductDto product = new ProductDto() { Id = 69, Name = "Rocca", Price = 10000000 };
        //act
        products.AddProduct(product);
        //assert
        Assert.Single(products._products);
    }

    [Fact]
    public void GetProductById_ShouldReturnProduct()
    {
        // arrange
        IProductFactory productFactory = new ProductFactory();
        ProductServices products = new ProductServices(productFactory);
        for (int i = 0; i < 125; i++)
        {
            products._products.Add(new Product { Id = i, Name = $"Test {i}", Price = i*16 });
        }

        // act
        var result = products.GetProductById(69);

        // assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnAll125Products()
    {
        // arrange
        IProductFactory productFactory = new ProductFactory();
        ProductServices products = new ProductServices(productFactory);
        for (int i = 0; i < 125; i++)
        {
            products._products.Add(new Product { Id = i, Name = $"Test {i}", Price = i * 16 });
        }

        // act
        var result = products._products.Count;

        // assert
        Assert.NotNull(result);
        Assert.Equal(result, 125);
    }

    [Fact]
    public void GetProductById_ShouldThrowExceptionIfNotFound()
    {
        // arrange
        IProductFactory productFactory = new ProductFactory();
        ProductServices products = new ProductServices(productFactory);

        // act
        var exception = Assert.Throws<Exception>(() => products.GetProductById(999));

        //assert
        Assert.Equal("Product not found", exception.Message);
    }

    [Fact]
    public void GetProductById_ShouldThrowExceptionIfNotFound_Moq()
    {
        // arrange
        var mockProductService = new Mock<IProductService>();
        mockProductService.Setup(service => service.GetProductById(It.IsAny<int>()))
                          .Throws(new Exception("Product not found"));

        // act
        var exception = Assert.Throws<Exception>(() => mockProductService.Object.GetProductById(999));

        // assert
        Assert.Equal("Product not found", exception.Message);
    }
}
