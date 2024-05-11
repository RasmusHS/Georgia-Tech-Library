using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Member;
using GTL.Application.DTO.Member.Command;
using GTL.Application.Queries.Member;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public MemberController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberRequest request)
        {
            CreateMemberRequest.Validator validator = new CreateMemberRequest.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateMemberCommand command = new CreateMemberCommand(
                    request.Name,
                    request.HomeAddress,
                    request.CampusAddress,
                    request.PhoneNumber,
                    request.Email,
                    request.Type,
                    request.SSN);
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
        public async Task<IActionResult> GetMembers()
        {
            //GetAllMembersQuery query = new GetAllMembersQuery();
            //var result = await _dispatcher.Dispatch(query);
            //return FromResult(result);
        }

        
    }
}
