using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.ReserveItem.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ReserveItem.Handlers
{
    public class GetReservationQueryHandler : IQueryHandler<GetReservationQuery, QueryReservationsDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ReserveItemEntity> _repository;

        public GetReservationQueryHandler(IGenericRepository<ReserveItemEntity> repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<QueryReservationsDto>> Handle(GetReservationQuery query, CancellationToken cancellationToken = default)
        {
            object[] id = { query.MemberId, query.ItemCatalogId };
            var reservation = await _repository.GetByIdAsync(id);
            var reservationDto = _mapper.Map<QueryReservationsDto>(reservation);
            return Result.Ok(reservationDto);
        }
    }
}
