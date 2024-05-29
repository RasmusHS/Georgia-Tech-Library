using GTL.Application.Commands.Member.Handlers;
using GTL.Application.Commands.Member;
using GTL.Application.Data;
using GTL.Domain.Models;

namespace GTL.Application.Test.Member
{
    public class DeleteMemberCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new DeleteMemberCommand(Guid.NewGuid());

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.Delete(It.IsAny<int>()));
            repositoryMock.Setup(r => r.Save());

            var handler = new DeleteMemberCommandHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
        }
    }
}
