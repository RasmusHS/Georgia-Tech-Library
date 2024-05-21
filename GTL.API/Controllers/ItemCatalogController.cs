using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Author;
using GTL.Application.Commands.ItemCatalog;
using GTL.Application.DTO.ItemCatalog.Command;
using GTL.Application.DTO.ItemCatalog.Command.WithAuthors;
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

        [HttpPost]
        public async Task<IActionResult> CreateCatalogEntry(CreateCatalogEntryWithAuthorsRequestDto request)
        {
            CreateCatalogEntryWithAuthorsRequestDto.Validator validator = new CreateCatalogEntryWithAuthorsRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateCatalogEntryWithAuthorsCommand command = new CreateCatalogEntryWithAuthorsCommand(
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
                request.Authors.Select(x => new UpdateAuthorCommand
                {
                    ItemCatalogId = x.ItemCatalogId,
                    Name = x.Name,
                    RowVersion = x.RowVersion
                }).ToList(),
                request.RowVersion);
            var commandResult = await _dispatcher.Dispatch(command);
            return FromResult(commandResult);
        }
    }
}
