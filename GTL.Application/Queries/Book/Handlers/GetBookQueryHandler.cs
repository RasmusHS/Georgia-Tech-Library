using AutoMapper;
using MediatR;
using GTL.Application.DTO.Book.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.Book.Handlers
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, QueryBookDto>
    {
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryBookDto>> Handle(GetBookQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
