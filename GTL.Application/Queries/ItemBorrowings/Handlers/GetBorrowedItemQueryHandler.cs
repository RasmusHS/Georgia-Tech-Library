using AutoMapper;
using GTL.Application.DTO.ItemBorrowings.Query;
using GTL.Domain.Common;
using GTL.Application.Data;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ItemBorrowings.Handlers
{
    public class GetBorrowedItemQueryHandler : IQueryHandler<GetBorrowedItemQuery, QueryItemBorrowingsDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemBorrowingsEntity> _repository;

        public GetBorrowedItemQueryHandler(IGenericRepository<ItemBorrowingsEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<QueryItemBorrowingsDto>> Handle(GetBorrowedItemQuery query, CancellationToken cancellationToken = default)
        {
            object[] id = { query.MemberId, query.ItemId, query.StartDate };
            var itemBorrowing = await _repository.GetByIdAsync(id);
            var itemBorrowingDto = _mapper.Map<QueryItemBorrowingsDto>(itemBorrowing);
            return Result.Ok(itemBorrowingDto);
        }
    }
}
