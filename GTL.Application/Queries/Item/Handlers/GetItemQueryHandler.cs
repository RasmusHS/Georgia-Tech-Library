using AutoMapper;
using GTL.Application.DTO.Item.Query;
using GTL.Domain.Common;
using GTL.Application.Data;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Item.Handlers
{
    public class GetItemQueryHandler : IQueryHandler<GetItemQuery, QueryItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemEntity> _repository;

        public GetItemQueryHandler(IGenericRepository<ItemEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<QueryItemDto>> Handle(GetItemQuery query, CancellationToken cancellationToken = default)
        {
            var item = await _repository.GetByIdAsync(query.ItemId);
            var itemDto = _mapper.Map<QueryItemDto>(item);
            return Result.Ok(itemDto);
        }
    }
}
