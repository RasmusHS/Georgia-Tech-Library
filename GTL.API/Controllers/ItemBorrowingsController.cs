using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.ItemBorrowings;
using GTL.Application.DTO.ItemBorrowings.Command;
using GTL.Application.Queries.ItemBorrowings;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/borrow")]
    [ApiController]
    public class ItemBorrowingsController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public ItemBorrowingsController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrowing(CreateBorrowingRequestDto request)
        {
            CreateBorrowingRequestDto.Validator validator = new CreateBorrowingRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateBorrowingCommand command = new CreateBorrowingCommand(
                    request.MemberId,
                    request.ItemId,
                    request.StartDate,
                    request.Due,
                    request.ReturnedDate
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrowings()
        {
            GetAllBorrowedItemsQuery query = new GetAllBorrowedItemsQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{memberId}/{itemId}/{startDate}")]
        public async Task<IActionResult> GetBorrowing(Guid memberId, Guid itemId, DateTime startDate)
        {
            var result = await _dispatcher.Dispatch(new GetBorrowedItemQuery(memberId, itemId, startDate));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBorrowing(UpdateBorrowingRequestDto request)
        {
            UpdateBorrowingRequestDto.Validator validator = new UpdateBorrowingRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                UpdateBorrowingCommand command = new UpdateBorrowingCommand(
                    request.MemberId,
                    request.ItemId,
                    request.StartDate,
                    request.Due,
                    request.ReturnedDate,
                    request.RowVersion
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBorrowing(DeleteBorrowingRequestDto request)
        {
            DeleteBorrowingRequestDto.Validator validator = new DeleteBorrowingRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                DeleteBorrowingCommand command = new DeleteBorrowingCommand(
                    request.MemberId,
                    request.ItemId,
                    request.StartDate
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }
    }
}
