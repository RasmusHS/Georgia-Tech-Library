using AutoMapper;
using MediatR;
using GTL.Application.DTO.BookBorrowerings.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.BookBorrowings.Handlers
{
    public class GetBorrowedBookQueryHandler : IQueryHandler<GetBorrowedBookQuery, QueryBookBorrowingsDto>
    {
        private readonly IMapper _mapper;

        public GetBorrowedBookQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryBookBorrowingsDto>> Handle(GetBorrowedBookQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
