using GTL.Application.Commands.ItemCatalog.WithItems;
using GTL.Application.Commands.Author;
using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Domain.Common;
using GTL.Application.Commands.Item;

namespace GTL.Application.Test.ItemCatalog.WithItems
{
    public class CreateCatalogEntryWithItemsCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateCatalogEntryWithItemsCommand
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
                new List<CreateItemCommand>
                {
                    new CreateItemCommand
                    {
                        IsLendable = true,
                        DateCreated = DateTime.Now,
                        Condition = "Good"
                    },
                    new CreateItemCommand
                    {
                        IsLendable = false,
                        DateCreated = DateTime.Now,
                        Condition = "Fair"
                    }
                }
            );

            var catalogResult = Result<ItemCatalogEntity>.Ok(new ItemCatalogEntity());

            var catalogRepositoryMock = new Mock<IGenericRepository<ItemCatalogEntity>>();
            catalogRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<ItemCatalogEntity>())).ReturnsAsync(catalogResult);

            var authorResult = Result<AuthorEntity>.Ok(new AuthorEntity());

            var authorRepositoryMock = new Mock<IGenericRepository<AuthorEntity>>();
            authorRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<AuthorEntity>())).ReturnsAsync(authorResult);

            var itemResult = Result<ItemEntity>.Ok(new ItemEntity());

            var itemRepositoryMock = new Mock<IGenericRepository<ItemEntity>>();
            itemRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<ItemEntity>())).ReturnsAsync(itemResult);

            var handler = new CreateCatalogEntryWithItemsCommandHandler(
                catalogRepositoryMock.Object,
                authorRepositoryMock.Object,
                itemRepositoryMock.Object
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
            var command = new CreateCatalogEntryWithItemsCommand
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
                new List<CreateItemCommand>
                {
                    new CreateItemCommand
                    {
                        IsLendable = true,
                        DateCreated = DateTime.Now,
                        Condition = "Good"
                    },
                    new CreateItemCommand
                    {
                        IsLendable = false,
                        DateCreated = DateTime.Now,
                        Condition = "Fair"
                    }
                }
            );

            var errorMessage = "Invalid command";

            var catalogRepositoryMock = new Mock<IGenericRepository<ItemCatalogEntity>>();
            catalogRepositoryMock.Setup(r => r.InsertAsync(It.IsAny<ItemCatalogEntity>())).ThrowsAsync(new Exception(errorMessage));

            var authorRepositoryMock = new Mock<IGenericRepository<AuthorEntity>>();
            var itemRepositoryMock = new Mock<IGenericRepository<ItemEntity>>();

            var handler = new CreateCatalogEntryWithItemsCommandHandler(
                catalogRepositoryMock.Object,
                authorRepositoryMock.Object,
                itemRepositoryMock.Object
            );

            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));

            // Assert
            Assert.Equal(errorMessage, result.Message);
        }
    }
}
