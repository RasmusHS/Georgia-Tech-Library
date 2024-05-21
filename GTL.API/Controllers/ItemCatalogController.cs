using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Author;
using GTL.Application.Commands.ItemCatalog;
using GTL.Application.DTO.ItemCatalog.Command;
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
                    request.Authors.Select(x => new CreateAuthorToNewItemCatalogCommand
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
            GetAllCatalogEntriesQuery query = new GetAllCatalogEntriesQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }
    }
}
