using AutoFixture;
using Moq;
using shop.service.Services;
using shop.domain.Interfaces;
using shop.domain.Entities;
using shop.service.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;

namespace shop.unitTest.shop.service.Service;

[Trait("shop.service", "")]
public class ProductCategoryServiceTest
{
    private Mock<IProductCategoryRepository> _repositoryMock;
    private IProductCategoryService _service;

    public ProductCategoryServiceTest()
    {
        _repositoryMock = new Mock<IProductCategoryRepository>();
        _service = new ProductCategoryService(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Successfully returning a paginated list of product categories")]
    public async Task Given_PageRequested_When_GetAllIsCalled_Then_ShouldReturnPaginatedList()
    {
        /*** Dummy ***/
        var parameters = new ProductCategoryParameters();
        /*** ---- ***/

        /** Stubs **/
        var selectWithResponse = new Fixture()
            .CreateMany<ProductCategory>(8);

        _repositoryMock
            .Setup(r => r.SelectWith(It.IsAny<ProductCategoryParameters>()))
            .ReturnsAsync(selectWithResponse.ToList());

        var totalResponse = 200;

        _repositoryMock
           .Setup(r => r.Total())
           .ReturnsAsync(totalResponse);
        /** --- **/

        var pagedList = await _service.GetAll(parameters);

        _repositoryMock.Verify(r => r.SelectWith(It.IsAny<ProductCategoryParameters>()), Times.Once);
        _repositoryMock.Verify(r => r.Total(), Times.Once);

        Assert.IsType<PagedList<ProductCategoryResponse>>(pagedList);
        Assert.True(pagedList.RecordsFiltered <= totalResponse);
    }
}