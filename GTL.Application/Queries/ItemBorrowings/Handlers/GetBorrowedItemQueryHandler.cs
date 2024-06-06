using AutoMapper;
using MediatR;
using GTL.Application.DTO.ItemBorrowings.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.ItemBorrowings.Handlers
{
    public class GetBorrowedItemQueryHandler : IQueryHandler<GetBorrowedItemQuery, QueryItemBorrowingsDto>
    {
        private readonly IMapper _mapper;

        public GetBorrowedItemQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryItemBorrowingsDto>> Handle(GetBorrowedItemQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
