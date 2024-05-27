using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Acquisitions.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Acquisitions.Handlers
{
    public class GetAcquisitionQueryHandler : IQueryHandler<GetAcquisitionQuery, QueryAcquisitionDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<AcquisitionEntity> _repository;

        public GetAcquisitionQueryHandler(IGenericRepository<AcquisitionEntity> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<QueryAcquisitionDto>> Handle(GetAcquisitionQuery query, CancellationToken cancellationToken = default)
        {
            object[] id = { query.MemberId, query.ItemCatalogId, query.RequestDate };
            var acquisition = await _repository.GetByIdAsync(id);
            var acquisitionDto = _mapper.Map<QueryAcquisitionDto>(acquisition);
            return Result.Ok(acquisitionDto);
        }
    }
}
