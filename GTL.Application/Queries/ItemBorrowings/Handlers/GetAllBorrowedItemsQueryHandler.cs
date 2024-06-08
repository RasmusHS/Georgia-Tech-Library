using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.ItemBorrowings.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ItemBorrowings.Handlers
{
    public class GetAllBorrowedItemsQueryHandler : IQueryHandler<GetAllBorrowedItemsQuery, CollectionResponseBase<QueryItemBorrowingsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemBorrowingsEntity> _repository;

        public GetAllBorrowedItemsQueryHandler(IGenericRepository<ItemBorrowingsEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CollectionResponseBase<QueryItemBorrowingsDto>>> Handle(GetAllBorrowedItemsQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryItemBorrowingsDto> result = new List<QueryItemBorrowingsDto>();
            var itemBorrowings = await _repository.GetAllAsync();
            foreach (var itemBorrowing in itemBorrowings)
            {
                QueryItemBorrowingsDto dto = new QueryItemBorrowingsDto();
                dto.MemberId = itemBorrowing.MemberId;
                dto.ItemId = itemBorrowing.ItemId;
                dto.StartDate = itemBorrowing.StartDate;
                dto.Due = itemBorrowing.Due;
                dto.ReturnedDate = itemBorrowing.ReturnedDate;
                dto.RowVersion = itemBorrowing.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryItemBorrowingsDto>()
            {
                Data = result
            };
        }
    }
}
