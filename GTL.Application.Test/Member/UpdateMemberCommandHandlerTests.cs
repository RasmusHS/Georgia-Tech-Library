using GTL.Application.Commands.Member.Handlers;
using GTL.Application.Commands.Member;
using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Domain.Common;


namespace GTL.Application.Test.Member
{
    public class UpdateMemberCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            byte[] rowVersion = new byte[] { 1, 2, 3, 4, 5, 6 };
            var command = new UpdateMemberCommand(Guid.NewGuid(), "John Doe", "123 Main St", "456 University Ave", "1234567890", "john.doe@example.com", "Student", "123-45-6789", DateTime.Now.AddDays(30), "Librarian", rowVersion);

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
            repositoryMock.Setup(r => r.GetByIdAsync(command.MemberId)).ReturnsAsync(memberResult);
            repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<MemberEntity>())).ReturnsAsync(memberResult);

            var handler = new UpdateMemberCommandHandler(repositoryMock.Object);

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
            byte[] rowVersion = new byte[] { 1, 2, 3, 4, 5, 6 };
            var command = new UpdateMemberCommand(Guid.NewGuid(), "John Doe", "123 Main St", "456 University Ave", "1234567890", "john.doe@example.com", "Student", "123-45-6789", DateTime.Now.AddDays(30), "Librarian", rowVersion);

            var errorMessage = "Invalid command";

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.GetByIdAsync(command.MemberId)).ThrowsAsync(new Exception(errorMessage));

            var handler = new UpdateMemberCommandHandler(repositoryMock.Object);

            // Act
            var result = await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));

            // Assert
            Assert.Equal(errorMessage, result.Message);
        }
    }
}
