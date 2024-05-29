using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Member.Query;
using GTL.Application.Queries.Member;
using GTL.Application.Queries.Member.Handlers;
using GTL.Domain.Common;
using GTL.Domain.Models;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GTL.Application.Test.Member
{
    public class GetAllMembersQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidQuery_ReturnsCollectionResponseWithMembers()
        {
            // Arrange
            var queryDto = new List<QueryMemberDto>
                    {
                        new QueryMemberDto
                        {
                            MemberId = Guid.NewGuid(),
                            Name = "John Doe",
                            HomeAddress = "123 Main St",
                            CampusAddress = "456 University Ave",
                            PhoneNumber = "1234567890",
                            Email = "john.doe@example.com",
                            Type = "Student",
                            SSN = "123-45-6789",
                            CardExpirationDate = new DateTime(2022, 12, 31),
                            EmployeePosition = "Librarian",
                            RowVersion = new byte[] { 1, 2, 3 }
                        },
                        new QueryMemberDto
                        {
                            MemberId = Guid.NewGuid(),
                            Name = "Jane Smith",
                            HomeAddress = "456 Elm St",
                            CampusAddress = "789 College Ave",
                            PhoneNumber = "0987654321",
                            Email = "jane.smith@example.com",
                            Type = "Faculty",
                            SSN = "987-65-4321",
                            CardExpirationDate = new DateTime(2023, 12, 31),
                            EmployeePosition = "Professor",
                            RowVersion = new byte[] { 4, 5, 6 }
                        }
                    };

            var query = new GetAllMembersQuery();

            var repositoryMock = new Mock<IGenericRepository<MemberEntity>>();
            repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(queryDto.Select(m => new MemberEntity
            {
                MemberId = m.MemberId,
                Name = m.Name,
                HomeAddress = m.HomeAddress,
                CampusAddress = m.CampusAddress,
                PhoneNumber = m.PhoneNumber,
                Email = m.Email,
                Type = m.Type,
                SSN = m.SSN,
                CardExpirationDate = m.CardExpirationDate,
                EmployeePosition = m.EmployeePosition,
                RowVersion = m.RowVersion
            }).ToList());

            var mapperMock = new Mock<IMapper>();

            var handler = new GetAllMembersQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CollectionResponseBase<QueryMemberDto>>(result.Value);
            Assert.Equal(2, result.Value.Data.Count());
            Assert.Equal("John Doe", result.Value.Data.ElementAt(0).Name);
            Assert.Equal("123 Main St", result.Value.Data.ElementAt(0).HomeAddress);
            Assert.Equal("456 University Ave", result.Value.Data.ElementAt(0).CampusAddress);
            Assert.Equal("1234567890", result.Value.Data.ElementAt(0).PhoneNumber);
            Assert.Equal("john.doe@example.com", result.Value.Data.ElementAt(0).Email);
            Assert.Equal("Student", result.Value.Data.ElementAt(0).Type);
            Assert.Equal("123-45-6789", result.Value.Data.ElementAt(0).SSN);
            Assert.Equal(new DateTime(2022, 12, 31), result.Value.Data.ElementAt(0).CardExpirationDate);
            Assert.Equal("Librarian", result.Value.Data.ElementAt(0).EmployeePosition);
            Assert.Equal(new byte[] { 1, 2, 3 }, result.Value.Data.ElementAt(0).RowVersion);
            Assert.Equal("Jane Smith", result.Value.Data.ElementAt(1).Name);
            Assert.Equal("456 Elm St", result.Value.Data.ElementAt(1).HomeAddress);
            Assert.Equal("789 College Ave", result.Value.Data.ElementAt(1).CampusAddress);
            Assert.Equal("0987654321", result.Value.Data.ElementAt(1).PhoneNumber);
            Assert.Equal("jane.smith@example.com", result.Value.Data.ElementAt(1).Email);
            Assert.Equal("Faculty", result.Value.Data.ElementAt(1).Type);
            Assert.Equal("987-65-4321", result.Value.Data.ElementAt(1).SSN);
            Assert.Equal(new DateTime(2023, 12, 31), result.Value.Data.ElementAt(1).CardExpirationDate);
            Assert.Equal("Professor", result.Value.Data.ElementAt(1).EmployeePosition);
            Assert.Equal(new byte[] { 4, 5, 6 }, result.Value.Data.ElementAt(1).RowVersion);
        }
    }
}
