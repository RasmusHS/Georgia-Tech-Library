using AutoMapper;
using GTL.Application.DTO.Member.Query;
using GTL.Application.Queries.Member.Handlers;
using GTL.Application.Queries.Member;
using GTL.Application.Data;
using GTL.Domain.Models;
using Moq;

namespace GTL.Application.Test.Member
{
    public class GetMemberQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidQuery_ReturnsOkResult()
        {
            // Arrange
            var query = new GetMemberQuery(Guid.NewGuid());

            var queryMemberDto = new QueryMemberDto
            {
                MemberId = Guid.NewGuid(),
                Name = "John Doe",
                HomeAddress = "123 Main St",
                CampusAddress = "456 University Ave",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                Type = "Student",
                SSN = "123-45-6789",
                EmployeePosition = "Librarian"
            };

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new MemberEntity());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<QueryMemberDto>(It.IsAny<MemberEntity>())).Returns(queryMemberDto);

            var handler = new GetMemberQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(queryMemberDto, result.Value);
        }
    }
}
