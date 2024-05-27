using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Author.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Author.Handlers
{
    public class GetAllAuthorsQueryHandler : IQueryHandler<GetAllAuthorsQuery, CollectionResponseBase<QueryAuthorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AuthorEntity> _repository;

        public GetAllAuthorsQueryHandler(IGenericRepository<AuthorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<QueryAuthorDto>>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryAuthorDto> result = new List<QueryAuthorDto>();
            var authors = await _repository.GetAllAsync();
            foreach (var author in authors)
            {
                QueryAuthorDto dto = new QueryAuthorDto();
                dto.ItemCatalogId = author.ItemCatalogId;
                dto.Name = author.Name;
                dto.RowVersion = author.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryAuthorDto>()
            {
                Data = result
            };
        }
    }
}
