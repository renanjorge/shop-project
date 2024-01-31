using AutoFixture;
using Moq;
using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.service.Services;

namespace shop.unitTest.shop.service.Service;

[Trait("shop.service", "")]
public class BaseServiceTest
{
    [Theory(DisplayName = "Update with invalid id and return null")]
    [MemberData(nameof(EntityMemberData.GetData), MemberType = typeof(EntityMemberData))]
    public async Task Given_NonExistentId_When_UpdateIsCalled_Then_ReturnsNull<TModel>(TModel model) where TModel : Entity
    {
        var _repositoryMock = new Mock<IRepository<TModel>>();
        var _service = new Mock<BaseService<TModel>>(_repositoryMock.Object) { CallBase = true };

        _repositoryMock
            .Setup(r => r.Select(It.IsAny<int>()))
            .ReturnsAsync(() => null);

        // Act
        await _service.Object.Update(It.IsAny<int>(), model);

        // Assert
        _repositoryMock.Verify(r => r.Select(It.IsAny<int>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<TModel>()), Times.Never);
    }

    [Theory(DisplayName = "Update with valid id and return entity")]
    [MemberData(nameof(EntityMemberData.GetData), MemberType = typeof(EntityMemberData))]
    public async Task Given_ExistentIdAndChangedEntity_When_UpdateIsCalled_Then_ReturnsEntity<TModel>(TModel model) where TModel : Entity
    {
        var _repositoryMock = new Mock<IRepository<TModel>>();
        var _service = new Mock<BaseService<TModel>>(_repositoryMock.Object) { CallBase = true };

        var selectResponse = new Fixture()
            .Create<TModel>();

        _repositoryMock
            .Setup(r => r.Select(It.IsAny<int>()))
            .ReturnsAsync(() => selectResponse);

        // Act
        await _service.Object.Update(It.IsAny<int>(), model);

        // Assert
        _repositoryMock.Verify(r => r.Select(It.IsAny<int>()), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<TModel>()), Times.Once);
    }

    [Theory(DisplayName = "Delete with invalid id and return null")]
    [MemberData(nameof(EntityMemberData.GetData), MemberType = typeof(EntityMemberData))]
    public async Task Given_NonExistentId_When_DeleteIsCalled_Then_ReturnsNull<TModel>(TModel model) where TModel : Entity
    {
        var _repositoryMock = new Mock<IRepository<TModel>>();
        var _service = new Mock<BaseService<TModel>>(_repositoryMock.Object) { CallBase = true };

        _repositoryMock
            .Setup(r => r.Select(It.IsAny<int>()))
            .ReturnsAsync(() => null);

        // Act
        await _service.Object.Delete(It.IsAny<int>());

        // Assert
        _repositoryMock.Verify(r => r.Select(It.IsAny<int>()), Times.Once);
        _repositoryMock.Verify(r => r.Delete(It.IsAny<TModel>()), Times.Never);
    }

    [Theory(DisplayName = "Delete with valid id and return entity")]
    [MemberData(nameof(EntityMemberData.GetData), MemberType = typeof(EntityMemberData))]
    public async Task Given_ExistentId_When_DeleteIsCalled_Then_ReturnsEntity<TModel>(TModel model) where TModel : Entity
    {
        var _repositoryMock = new Mock<IRepository<TModel>>();
        var _service = new Mock<BaseService<TModel>>(_repositoryMock.Object) { CallBase = true };

        var selectResponse = new Fixture()
          .Create<TModel>();

        _repositoryMock
            .Setup(r => r.Select(It.IsAny<int>()))
            .ReturnsAsync(() => selectResponse);

        // Act
        await _service.Object.Delete(It.IsAny<int>());

        // Assert
        _repositoryMock.Verify(r => r.Select(It.IsAny<int>()), Times.Once);
        _repositoryMock.Verify(r => r.Delete(It.IsAny<TModel>()), Times.Once);
    }
}
