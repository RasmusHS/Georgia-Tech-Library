using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Author.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Author.Handlers
{
    public class GetAuthorQueryHandler : IQueryHandler<GetAuthorQuery, QueryAuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AuthorEntity> _repository;

        public GetAuthorQueryHandler(IGenericRepository<AuthorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<QueryAuthorDto>> Handle(GetAuthorQuery query, CancellationToken cancellationToken = default)
        {
            object[] id = { query.ItemCatalogId, query.Name };
            var author = await _repository.GetByIdAsync(id);
            var authorDto = _mapper.Map<QueryAuthorDto>(author);
            return Result.Ok(authorDto);
        }
    }
}
