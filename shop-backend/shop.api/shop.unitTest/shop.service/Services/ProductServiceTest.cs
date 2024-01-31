using AutoFixture;
using Moq;
using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;
using shop.service.Interfaces;
using shop.service.Services;

namespace shop.unitTest.shop.service.Service;

[Trait("shop.service", "")]
public class ProductServiceTest
{
    private Mock<IProductRepository> _repositoryMock;
    private IProductService _service;

    public ProductServiceTest()
    {
        _repositoryMock = new Mock<IProductRepository>();
        _service = new ProductService(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Successfully returning a paginated list of products")]
    public async Task Given_PageRequested_When_GetAllIsCalled_Then_ShouldReturnPaginatedList()
    {
        /*** Dummy ***/
        var parameters = new ProductParameters();
        /*** ---- ***/

        /** Stubs **/
        var selectWithResponse = new Fixture()
            .CreateMany<Product>(8);

        _repositoryMock
            .Setup(r => r.SelectWith(It.IsAny<ProductParameters>()))
            .ReturnsAsync(selectWithResponse.ToList());

        var totalResponse = 200;

        _repositoryMock
           .Setup(r => r.Total())
           .ReturnsAsync(totalResponse);
        /** --- **/

        var pagedList = await _service.GetAll(parameters);

        _repositoryMock.Verify(r => r.SelectWith(It.IsAny<ProductParameters>()), Times.Once);
        _repositoryMock.Verify(r => r.Total(), Times.Once);

        Assert.IsType<PagedList<ProductResponse>>(pagedList);
        Assert.True(pagedList.RecordsFiltered <= totalResponse);
    }
}
