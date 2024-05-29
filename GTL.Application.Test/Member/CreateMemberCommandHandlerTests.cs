using GTL.Application.Commands.Member.Handlers;
using GTL.Application.Commands.Member;
using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Domain.Common;

namespace GTL.Application.Test.Member
{
    public class CreateMemberCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var command = new CreateMemberCommand("John Doe", "123 Main St", "456 University Ave", "1234567890", "john.doe@example.com", "Student", "123-45-6789", "Librarian");

            Result<MemberEntity> memberResult = MemberEntity.Create
                (
                command.Name,
                command.HomeAddress,
                command.CampusAddress,
                command.PhoneNumber,
                command.Email,
                command.Type,
                command.SSN,
                command.EmployeePosition
                );

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.InsertAsync(It.IsAny<MemberEntity>())).ReturnsAsync(memberResult);

            var handler = new CreateMemberCommandHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(memberResult.Success.ToString(), result.Success.ToString());
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsFailureResult()
        {
            // Arrange
            var command = new CreateMemberCommand("John Doe", "123 Main St", "456 University Ave", "1234567890", "john.doe@example.com", "Student", "123-45-6789", "Librarian");

            var errorMessage = "Invalid command";

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.InsertAsync(It.IsAny<MemberEntity>())).ThrowsAsync(new Exception(errorMessage));

            var handler = new CreateMemberCommandHandler(repositoryMock.Object);

            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));

            // Assert
            Assert.Equal(errorMessage, result.Message);
        }
    }
}
