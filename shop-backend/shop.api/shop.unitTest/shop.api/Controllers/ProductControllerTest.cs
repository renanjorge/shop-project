using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shop.api.Controllers;
using shop.domain.Interfaces.Services;
using shop.domain.Models.DTOs;
using shop.domain.Models.DTOs.Product;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

namespace shop.unitTest.shop.api.Controllers;

[Trait("shop.api", "")]
public class ProductControllerTest
{
    private Mock<IProductService> _serviceMock;
    private ProductController _controller;

    public ProductControllerTest()
    {
        _serviceMock = new Mock<IProductService>();
        _controller = new ProductController(_serviceMock.Object);
    }

    [Fact(DisplayName = "GET /api/products returns http status code 200")]
    public async Task Given_ProductParametersDefault_When_GetAllProducts_Then_ReturnsOk()
    {
        // Arrange
        var parameteres = new ProductParameters();

        var getAllResponse = new Fixture()
            .Create<PagedList<ProductResponse>>();

        _serviceMock
            .Setup(s => s.GetAll(It.IsAny<ProductParameters>()))
            .ReturnsAsync(getAllResponse);

        // Act
        var okResult = await _controller.Get(parameteres) as OkObjectResult;

        // Assert
        Assert.NotNull(okResult.Value);
        Assert.IsType<PagedList<ProductResponse>>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact(DisplayName = "GET /api/products/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_GetProductById_Then_ReturnsNotFound()
    {
        // Arrange
        _serviceMock
            .Setup(s => s.GetById(It.IsAny<int>()))
            .ReturnsAsync(() => null);

        // Act
        var notFoundResult = await _controller.Get(1) as NotFoundResult;

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Fact(DisplayName = "GET /api/products/{id} returns http status code 200")]
    public async Task Given_ExistentId_When_GetProductById_Then_ReturnsOk()
    {
        // Arrange
        var getByIdResponse = new Fixture()
            .Create<Product>();

        _serviceMock
            .Setup(s => s.GetById(It.IsAny<int>()))
            .ReturnsAsync(getByIdResponse);

        // Act
        var okResult = await _controller.Get(1) as OkObjectResult;

        // Assert
        Assert.NotNull(okResult.Value);
        Assert.IsType<ProductResponse>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact(DisplayName = "POST /api/products returns http status code 201")]
    public async Task Given_ProductRequestBody_When_AddProduct_Then_ReturnsCreated201()
    {
        // Arrange
        var productRequestBody = new ProductRequestBody();
        var getByIdResponse = new Fixture()
            .Create<Product>();

        _serviceMock
           .Setup(s => s.Add(It.IsAny<Product>()))
           .ReturnsAsync(getByIdResponse);

        _serviceMock
            .Setup(s => s.GetById(It.IsAny<int>()))
            .ReturnsAsync(getByIdResponse);

        // Act
        var createdResult = await _controller.Post(productRequestBody) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(createdResult.Value);
        Assert.IsType<ProductResponse>(createdResult.Value);
        Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
    }

    [Fact(DisplayName = "PUT /api/products/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_UpdateProduct_Then_ReturnsNotFound404()
    {
        // Arrange
        var productRequestBody = new ProductRequestBody();

        _serviceMock
           .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Product>()))
           .ReturnsAsync(() => null);

        // Act
        var notFoundResult = await _controller.Put(1, productRequestBody) as NotFoundResult;

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Fact(DisplayName = "PUT /api/products/{id} returns http status code 204")]
    public async Task Given_ExistentId_When_UpdateProduct_Then_ReturnsNoContent204()
    {
        // Arrange
        var productRequestBody = new ProductRequestBody();

        var updateResponse = new Fixture()
           .Create<Product>();

        _serviceMock
           .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Product>()))
           .ReturnsAsync(updateResponse);

        // Act
        var notContentResult = await _controller.Put(1, productRequestBody) as NoContentResult;

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, notContentResult.StatusCode);
    }

    [Fact(DisplayName = "DELETE /api/products/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_DeleteProduct_Then_ReturnsNotFound404()
    {
        // Arrange
        _serviceMock
           .Setup(s => s.Delete(It.IsAny<int>()))
           .ReturnsAsync(() => null);

        // Act
        var notFoundResult = await _controller.Delete(1) as NotFoundResult;

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Fact(DisplayName = "DELETE /api/products/{id} returns http status code 204")]
    public async Task Given_ExistentId_When_DeleteProduct_Then_ReturnsNoContent204()
    {
        // Arrange
        var deleteResponse = new Fixture()
           .Create<Product>();

        _serviceMock
           .Setup(s => s.Delete(It.IsAny<int>()))
           .ReturnsAsync(deleteResponse);

        // Act
        var notFoundResult = await _controller.Delete(1) as NoContentResult;

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, notFoundResult.StatusCode);
    }
}