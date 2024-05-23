using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Acquisitions;
using GTL.Application.Commands.Author;
using GTL.Application.Commands.Item;
using GTL.Application.Commands.ItemCatalog;
using GTL.Application.Commands.ItemCatalog.WithAcquisitions;
using GTL.Application.Commands.ItemCatalog.WithItems;
using GTL.Application.DTO.ItemCatalog.Command;
using GTL.Application.DTO.ItemCatalog.Command.WithAcquisitions;
using GTL.Application.DTO.ItemCatalog.Command.WithItem;
using GTL.Application.Queries.ItemCatalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/catalogItems")]
    [ApiController]
    public class ItemCatalogController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public ItemCatalogController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [Route("createCatalogEntryWithItems")]
        [HttpPost]
        public async Task<IActionResult> CreateCatalogEntryWithItems(CreateCatalogEntryWithItemsRequestDto request)
        {
            CreateCatalogEntryWithItemsRequestDto.Validator validator = new CreateCatalogEntryWithItemsRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateCatalogEntryWithItemsCommand command = new CreateCatalogEntryWithItemsCommand(
                    request.ISBN,
                    request.Title,
                    request.Description,
                    request.SubjectArea,
                    request.Type,
                    request.Edition,
                    request.Authors.Select(x => new CreateAuthorCommand
                    {
                        ItemCatalogId = x.ItemCatalogId,
                        Name = x.Name
                    }).ToList(),
                    request.Items.Select(x => new CreateItemCommand
                    {
                        ItemCatalogId = x.ItemCatalogId,
                        IsLendable = x.IsLendable,
                        DateCreated = x.DateCreated,
                        Condition = x.Condition
                    }).ToList());
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            else
            {
                List<string> errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return Error(errors);
            }
        }

        [Route("createCatalogEntryWithAcquisitions")]
        [HttpPost]
        public async Task<IActionResult> CreateCatalogEntryWithAcquisitions(CreateCatalogEntryWithAcquisitionsRequestDto request)
        {
            CreateCatalogEntryWithAcquisitionsRequestDto.Validator validator = new CreateCatalogEntryWithAcquisitionsRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateCatalogEntryWithAcquisitionsCommand command = new CreateCatalogEntryWithAcquisitionsCommand(
                    request.ISBN,
                    request.Title,
                    request.Description,
                    request.SubjectArea,
                    request.Type,
                    request.Edition,
                    request.Authors.Select(x => new CreateAuthorCommand
                    {
                        ItemCatalogId = x.ItemCatalogId,
                        Name = x.Name
                    }).ToList(),
                    request.Acquisitions.Select(x => new CreateAcquisitionCommand
                    {
                        MemberId = x.MemberId,
                        ItemCatalogId = x.ItemCatalogId,
                        RequestDate = x.RequestDate,
                        Amount = x.Amount
                    }).ToList());
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
        public async Task<IActionResult> GetCatalogEntries()
        {
            GetAllItemCatalogEntriesQuery query = new GetAllItemCatalogEntriesQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{itemCatalogId}")]
        public async Task<IActionResult> GetCatalogEntry(Guid itemCatalogId)
        {
            var result = await _dispatcher.Dispatch(new GetItemCatalogEntryQuery(itemCatalogId));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalogEntry(UpdateCatalogEntryRequestDto request)
        {
            UpdateCatalogEntryCommand command = new UpdateCatalogEntryCommand(
                request.ItemCatalogId,
                request.ISBN,
                request.Title,
                request.Description,
                request.SubjectArea,
                request.Type,
                request.Edition,
                request.RowVersion);
            var commandResult = await _dispatcher.Dispatch(command);
            return FromResult(commandResult);
        }

        [HttpDelete]
        [Route("{itemCatalogId}")]
        public async Task<IActionResult> DeleteCatalogEntry(Guid itemCatalogId)
        {
            var result = await _dispatcher.Dispatch(new DeleteCatalogEntryCommand(itemCatalogId));
            return FromResult(result);
        }
    }
}
