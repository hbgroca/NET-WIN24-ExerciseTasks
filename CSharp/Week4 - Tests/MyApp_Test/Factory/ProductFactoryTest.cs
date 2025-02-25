using Moq;
using MyApp.Dtos;
using MyApp.Factory;
using MyApp.Interfaces;
using MyApp.Models;
using MyApp.Services;
using Xunit;
using Moq;

namespace MyApp_Test.Factory;

public class ProductFactoryTest
{


    [Fact]
    public void Create_ShouldReturnProduct_WhenValidProductDtoIsProvided()
    {
        // Arrange
        ProductFactory productFactory = new ProductFactory();

        var productDto = new ProductDto
        {
            Id = 69,
            Name = "Test 1",
            Price = 19.69m
        };

        // Act
        var product = productFactory.Create(productDto);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(productDto.Id, product.Id);
        Assert.Equal(productDto.Name, product.Name);
        Assert.Equal(productDto.Price, product.Price);
    }

    [Fact]
    public void Create_ShouldReturnNull_WhenExceptionOccurs()
    {
        // Arrange
        ProductDto productDto = null!; // Detta kommer att orsaka en NullReferenceException
        ProductFactory productFactory = new ProductFactory();

        // Act
        var product = productFactory.Create(productDto);

        // Assert
        Assert.Null(product);
    }


    [Fact]
    public void Create_ShouldBeCalled_WhenCreatingProduct()
    {
        // Arrange
        var productDto = new ProductDto { Id = 1, Name = "Test Product", Price = 10.0m };

        // Mocka fabriken och sätt upp förväntat beteende
        var mockProductFactory = new Mock<IProductFactory>();
        mockProductFactory
            .Setup(fa => fa.Create(It.IsAny<ProductDto>()))
            .Returns(new Product { Id = productDto.Id, Name = productDto.Name, Price = productDto.Price });

        // Act
        var product = mockProductFactory.Object.Create(productDto);

        // Assert
        mockProductFactory.Verify(fa => fa.Create(It.IsAny<ProductDto>()), Times.Once);
        Assert.NotNull(product); // Kontrollera att en produkt faktiskt skapas
        Assert.Equal(productDto.Id, product.Id); // Verifiera att rätt data returneras
        Assert.Equal(productDto.Name, product.Name);
        Assert.Equal(productDto.Price, product.Price);
    }
}
