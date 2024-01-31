using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using shop.api.Controllers;
using shop.domain.Entities;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;
using shop.service.Interfaces;

namespace shop.unitTest.shop.api.Controllers;

[Trait("shop.api", "")]
public class ProductCategoryControllerTest
{
    private Mock<IProductCategoryService> _serviceMock;
    private ProductCategoryController _controller;

    public ProductCategoryControllerTest()
    {
        _serviceMock = new Mock<IProductCategoryService>();
        _controller = new ProductCategoryController(_serviceMock.Object);
    }

    [Fact(DisplayName = "GET /api/product-categories returns http status code 200")]
    public async Task Given_ProductCategoryParametersDefault_When_GetAllProductCategories_Then_ReturnsOk()
    {
        // Arrange
        var parameteres = new ProductCategoryParameters();

        var getAllResponse = new Fixture()
            .Create<PagedList<ProductCategoryResponse>>();

        _serviceMock
            .Setup(s => s.GetAll(It.IsAny<ProductCategoryParameters>()))
            .ReturnsAsync(getAllResponse);

        // Act
        var okResult = await _controller.Get(parameteres) as OkObjectResult;

        // Assert
        Assert.NotNull(okResult.Value);
        Assert.IsType<PagedList<ProductCategoryResponse>>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact(DisplayName = "GET /api/product-categories/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_GetProductCategoryById_Then_ReturnsNotFound()
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

    [Fact(DisplayName = "GET /api/product-categories/{id} returns http status code 200")]
    public async Task Given_ExistentId_When_GetProductCategoryById_Then_ReturnsOk()
    {
        // Arrange
        var getByIdResponse = new Fixture()
            .Create<ProductCategory>();

        _serviceMock
            .Setup(s => s.GetById(It.IsAny<int>()))
            .ReturnsAsync(getByIdResponse);

        // Act
        var okResult = await _controller.Get(1) as OkObjectResult;

        // Assert
        Assert.NotNull(okResult.Value);
        Assert.IsType<ProductCategoryResponse>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact(DisplayName = "POST /api/product-categories returns http status code 201")]
    public async Task Given_ProductCategoryRequestBody_When_AddProductCategory_Then_ReturnsCreated201()
    {
        // Arrange
        var productCategoryRequestBody = new ProductCategoryRequestBody();
        var getByIdResponse = new Fixture()
            .Create<ProductCategory>();

        _serviceMock
           .Setup(s => s.Add(It.IsAny<ProductCategory>()))
           .ReturnsAsync(getByIdResponse);

        _serviceMock
            .Setup(s => s.GetById(It.IsAny<int>()))
            .ReturnsAsync(getByIdResponse);

        // Act
        var createdResult = await _controller.Post(productCategoryRequestBody) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(createdResult.Value);
        Assert.IsType<ProductCategoryResponse>(createdResult.Value);
        Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
    }

    [Fact(DisplayName = "PUT /api/product-categories/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_UpdateProductCategory_Then_ReturnsNotFound404()
    {
        // Arrange
        var productRequestBody = new ProductCategoryRequestBody();

        _serviceMock
           .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<ProductCategory>()))
           .ReturnsAsync(() => null);

        // Act
        var notFoundResult = await _controller.Put(1, productRequestBody) as NotFoundResult;

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Fact(DisplayName = "PUT /api/product-categories/{id} returns http status code 204")]
    public async Task Given_ExistentId_When_UpdateProductCategory_Then_ReturnsNoContent204()
    {
        // Arrange
        var productCategoryRequestBody = new ProductCategoryRequestBody();

        var updateResponse = new Fixture()
           .Create<ProductCategory>();

        _serviceMock
           .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<ProductCategory>()))
           .ReturnsAsync(updateResponse);

        // Act
        var notContentResult = await _controller.Put(1, productCategoryRequestBody) as NoContentResult;

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, notContentResult.StatusCode);
    }

    [Fact(DisplayName = "DELETE /api/product-categories/{id} returns http status code 404")]
    public async Task Given_NonExistentId_When_DeleteProductCategory_Then_ReturnsNotFound404()
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

    [Fact(DisplayName = "DELETE /api/product-categories/{id} returns http status code 204")]
    public async Task Given_ExistentId_When_DeleteProductCategory_Then_ReturnsNoContent204()
    {
        // Arrange
        var deleteResponse = new Fixture()
           .Create<ProductCategory>();

        _serviceMock
           .Setup(s => s.Delete(It.IsAny<int>()))
           .ReturnsAsync(deleteResponse);

        // Act
        var notFoundResult = await _controller.Delete(1) as NoContentResult;

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, notFoundResult.StatusCode);
    }
}
