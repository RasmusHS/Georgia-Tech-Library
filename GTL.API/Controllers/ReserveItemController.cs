using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.ReserveItem;
using GTL.Application.DTO.ReserveItem.Command;
using GTL.Application.Queries.ReserveItem;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReserveItemController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public ReserveItemController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequestDto request)
        {
            CreateReservationRequestDto.Validator validator = new CreateReservationRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateReservationCommand command = new CreateReservationCommand(
                    request.MemberId,
                    request.ItemCatalogId,
                    //request.DateReserved,
                    request.Amount
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            GetAllReservationsQuery query = new GetAllReservationsQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{memberId}/{itemCatalogId}")]
        public async Task<IActionResult> GetReservation(Guid memberId, Guid itemCatalogId)
        {
            var result = await _dispatcher.Dispatch(new GetReservationQuery(memberId, itemCatalogId));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationRequestDto request)
        {
            UpdateReservationRequestDto.Validator validator = new UpdateReservationRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                UpdateReservationCommand command = new UpdateReservationCommand(
                    request.MemberId,
                    request.ItemCatalogId,
                    request.DateReserved,
                    request.Amount,
                    request.RowVersion
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(DeleteReservationRequestDto request)
        {
            DeleteReservationRequestDto.Validator validator = new DeleteReservationRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                DeleteReservationCommand command = new DeleteReservationCommand(
                    request.MemberId,
                    request.ItemCatalogId
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }
    }
}
