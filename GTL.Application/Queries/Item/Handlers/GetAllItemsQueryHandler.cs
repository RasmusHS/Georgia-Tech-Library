using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Item.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Item.Handlers
{
    public class GetAllItemsQueryHandler : IQueryHandler<GetAllItemsQuery, CollectionResponseBase<QueryItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemEntity> _repository;

        public GetAllItemsQueryHandler(IGenericRepository<ItemEntity> repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CollectionResponseBase<QueryItemDto>>> Handle(GetAllItemsQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryItemDto> result = new List<QueryItemDto>();
            var items = await _repository.GetAllAsync();
            foreach (var item in items)
            {
                QueryItemDto dto = new QueryItemDto();
                dto.ItemId = item.ItemId;
                dto.ItemCatalogId = item.ItemCatalogId;
                dto.IsLendable = item.IsLendable;
                dto.DateCreated = item.DateCreated;
                dto.Condition = item.Condition;
                dto.RowVersion = item.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryItemDto>()
            {
                Data = result
            };
        }
    }
}
