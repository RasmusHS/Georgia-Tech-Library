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
        public async Task<IActionResult> CreateMember(CreateMemberRequestDto request)
        {
            CreateMemberRequestDto.Validator validator = new CreateMemberRequestDto.Validator();
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
                    request.SSN,
                    request.EmployeePosition);
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
            GetAllMembersQuery query = new GetAllMembersQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{memberId}")]
        public async Task<IActionResult> GetMember(Guid memberId)
        {
            var result = await _dispatcher.Dispatch(new GetMemberQuery(memberId));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(UpdateMemberRequestDto request)
        {
            UpdateMemberCommand command = new UpdateMemberCommand(
                request.MemberId,
                request.Name,
                request.HomeAddress,
                request.CampusAddress,
                request.PhoneNumber,
                request.Email,
                request.Type,
                request.SSN,
                request.CardExpirationDate,
                request.EmployeePosition,
                request.RowVersion
                );
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpDelete]
        [Route("{memberId}")]
        public async Task<IActionResult> DeleteMember(Guid memberId)
        {
            var result = await _dispatcher.Dispatch(new DeleteMemberCommand(memberId));
            return FromResult(result);
        }
    }
}
