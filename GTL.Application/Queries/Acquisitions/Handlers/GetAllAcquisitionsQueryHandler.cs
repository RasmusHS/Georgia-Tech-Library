using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Acquisitions.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Acquisitions.Handlers
{
    public class GetAllAcquisitionsQueryHandler : IQueryHandler<GetAllAcquisitionsQuery, CollectionResponseBase<QueryAcquisitionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AcquisitionEntity> _repository;

        public GetAllAcquisitionsQueryHandler(IGenericRepository<AcquisitionEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<QueryAcquisitionDto>>> Handle(GetAllAcquisitionsQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryAcquisitionDto> result = new List<QueryAcquisitionDto>();
            var acquisitions = await _repository.GetAllAsync();
            foreach (var acquisition in acquisitions)
            {
                QueryAcquisitionDto dto = new QueryAcquisitionDto();
                dto.MemberId = acquisition.MemberId;
                dto.ItemCatalogId = acquisition.ItemCatalogId;
                dto.RequestDate = acquisition.RequestDate;
                dto.Amount = acquisition.Amount;
                dto.RowVersion = acquisition.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryAcquisitionDto>()
            {
                Data = result
            };
        }
    }
}
