using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Item;
using GTL.Application.DTO.Item.Command;
using GTL.Application.Queries.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public ItemController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(CreateItemRequestDto request)
        {
            CreateItemRequestDto.Validator validator = new CreateItemRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateItemCommand command = new CreateItemCommand(
                    request.ItemCatalogId,
                    request.IsLendable,
                    request.DateCreated,
                    request.Condition
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            else
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return Error(errors);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            GetAllItemsQuery query = new GetAllItemsQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<IActionResult> GetItem(Guid itemId)
        {
            var result = await _dispatcher.Dispatch(new GetItemQuery(itemId));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(UpdateItemRequestDto request)
        {
            UpdateItemRequestDto.Validator validator = new UpdateItemRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                UpdateItemCommand command = new UpdateItemCommand(
                    request.ItemId,
                    request.ItemCatalogId,
                    request.IsLendable,
                    request.DateCreated,
                    request.Condition,
                    request.RowVersion
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            else
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return Error(errors);
            }
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            var result = await _dispatcher.Dispatch(new DeleteItemCommand(itemId));
            return FromResult(result);
        }
    }
}
