using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Author;
using GTL.Application.DTO.Author.Command;
using GTL.Application.Queries.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public AuthorController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequestDto request)
        {
            CreateAuthorRequestDto.Validator validator = new CreateAuthorRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateAuthorCommand command = new CreateAuthorCommand(
                    request.ItemCatalogId,
                    request.Name
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            GetAllAuthorsQuery query = new GetAllAuthorsQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{itemCatalogId}/{name}")]
        public async Task<IActionResult> GetAuthor(Guid itemCatalogId, string name)
        {
            var result = await _dispatcher.Dispatch(new GetAuthorQuery(itemCatalogId, name));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorRequestDto request)
        {
            UpdateAuthorRequestDto.Validator validator = new UpdateAuthorRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                UpdateAuthorCommand command = new UpdateAuthorCommand(
                    request.ItemCatalogId,
                    request.CurrentName,
                    request.UpdatedName,
                    request.RowVersion
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(DeleteAuthorRequestDto request)
        {
            DeleteAuthorRequestDto.Validator validator = new DeleteAuthorRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                DeleteAuthorCommand command = new DeleteAuthorCommand(
                    request.ItemCatalogId,
                    request.Name
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }
    }
}
