using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.ReserveItem.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ReserveItem.Handlers
{
    public class GetAllReservationsQueryHandler : IQueryHandler<GetAllReservationsQuery, CollectionResponseBase<QueryReservationsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ReserveItemEntity> _repository;

        public GetAllReservationsQueryHandler(IGenericRepository<ReserveItemEntity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CollectionResponseBase<QueryReservationsDto>>> Handle(GetAllReservationsQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryReservationsDto> result = new List<QueryReservationsDto>();
            var reservations = await _repository.GetAllAsync();
            foreach (var reservation in reservations)
            {
                QueryReservationsDto dto = new QueryReservationsDto();
                dto.MemberId = reservation.MemberId;
                dto.ItemCatalogId = reservation.ItemCatalogId;
                dto.DateReserved = reservation.DateReserved;
                dto.Amount = reservation.Amount;
                dto.RowVersion = reservation.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryReservationsDto>()
            {
                Data = result
            };
        }
    }
}
