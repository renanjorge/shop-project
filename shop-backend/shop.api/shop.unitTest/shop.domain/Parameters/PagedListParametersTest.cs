using shop.domain.Models.Parameters;

namespace shop.unitTest.shop.domain.Parameters;

[Trait("shop.domain", "")]
public class PagedListParametersTest
{
    [Fact(DisplayName = "Invalid page number and large page size")]
    public void Given_InvalidPageNumberAndLargePageSize_When_AssigningParameters_Then_PageSizeIs100AndPageNumberIs0()
    {
        // Arrange
        var parameter = new PagedListParameters 
        { 
            PageNumber = -1,
            PageSize = 100
        };

        // Assert
        Assert.Equal(100, parameter.PageSize);
        Assert.Equal(1, parameter.PageNumber);
    }

    [Fact(DisplayName = "Page number 6 and page size 50")]
    public void Given_PageNumber2AndPageSize10_When_AssigningParameters_Then_SkipIs250AndTakeIs50()
    {
        // Arrange
        var parameter = new PagedListParameters
        {
            PageNumber = 6,
            PageSize = 50
        };

        // Assert
        Assert.Equal(250, parameter.Skip());
        Assert.Equal(50, parameter.Take());
    }
}