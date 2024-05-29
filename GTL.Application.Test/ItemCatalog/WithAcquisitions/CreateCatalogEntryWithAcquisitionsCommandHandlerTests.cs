using GTL.Application.Commands.ItemCatalog.WithAcquisitions;
using GTL.Application.Commands.Author;
using GTL.Application.Commands.Acquisitions;
using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Domain.Common;

namespace GTL.Application.Test.ItemCatalog.WithAcquisitions
{
    public class CreateCatalogEntryWithAcquisitionsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateCatalogEntryWithAcquisitionsCommand
            (
                "1234567890",
                "Sample Book",
                "This is a sample book",
                "Sample Subject",
                "Sample Type",
                "1st Edition",
                new List<CreateAuthorCommand>
                {
                    new CreateAuthorCommand
                    {
                        Name = "John Doe"
                    },
                    new CreateAuthorCommand
                    {
                        Name = "Jane Smith"
                    }
                },
                new List<CreateAcquisitionCommand>
                {
                    new CreateAcquisitionCommand
                    {
                        MemberId = Guid.NewGuid(),
                        ItemCatalogId = Guid.NewGuid(),
                        RequestDate = DateTime.Now,
                        Amount = 10
                    },
                    new CreateAcquisitionCommand
                    {
                        MemberId = Guid.NewGuid(),
                        ItemCatalogId = Guid.NewGuid(),
                        RequestDate = DateTime.Now,
                        Amount = 15
                    }
                }
            );

            var catalogResult = Result<ItemCatalogEntity>.Ok(new ItemCatalogEntity());

            var catalogRepositoryMock = new Mock<IGenericRepository<ItemCatalogEntity>>();
            catalogRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<ItemCatalogEntity>())).ReturnsAsync(catalogResult);

            var authorResult = Result<AuthorEntity>.Ok(new AuthorEntity());

            var authorRepositoryMock = new Mock<IGenericRepository<AuthorEntity>>();
            authorRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<AuthorEntity>())).ReturnsAsync(authorResult);

            var acquisitionResult = Result<AcquisitionEntity>.Ok(new AcquisitionEntity());

            var acquisitionRepositoryMock = new Mock<IGenericRepository<AcquisitionEntity>>();
            acquisitionRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<AcquisitionEntity>())).ReturnsAsync(acquisitionResult);

            var handler = new CreateCatalogEntryWithAcquisitionsCommandHandler(
                catalogRepositoryMock.Object,
                authorRepositoryMock.Object,
                acquisitionRepositoryMock.Object
            );

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(catalogResult.Success.ToString(), result.Success.ToString());
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsFailureResult()
        {
            // Arrange
            var command = new CreateCatalogEntryWithAcquisitionsCommand
            (
                "1234567890",
                "Sample Book",
                "This is a sample book",
                "Sample Subject",
                "Sample Type",
                "1st Edition",
                new List<CreateAuthorCommand>
                {
                    new CreateAuthorCommand
                    {
                        Name = "John Doe"
                    },
                    new CreateAuthorCommand
                    {
                        Name = "Jane Smith"
                    }
                },
                new List<CreateAcquisitionCommand>
                {
                    new CreateAcquisitionCommand
                    {
                        MemberId = Guid.NewGuid(),
                        ItemCatalogId = Guid.NewGuid(),
                        RequestDate = DateTime.Now,
                        Amount = 10
                    },
                    new CreateAcquisitionCommand
                    {
                        MemberId = Guid.NewGuid(),
                        ItemCatalogId = Guid.NewGuid(),
                        RequestDate = DateTime.Now,
                        Amount = 15
                    }
                }
            );

            var errorMessage = "Invalid command";

            var catalogRepositoryMock = new Mock<IGenericRepository<ItemCatalogEntity>>();
            catalogRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<ItemCatalogEntity>())).ThrowsAsync(new Exception(errorMessage));

            var authorRepositoryMock = new Mock<IGenericRepository<AuthorEntity>>();
            var acquisitionRepositoryMock = new Mock<IGenericRepository<AcquisitionEntity>>();

            var handler = new CreateCatalogEntryWithAcquisitionsCommandHandler(
                catalogRepositoryMock.Object,
                authorRepositoryMock.Object,
                acquisitionRepositoryMock.Object
            );

            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));

            // Assert
            Assert.Equal(errorMessage, result.Message);
        }
    }
}
