using AutoMapper;
using GTL.Application;
using GTL.Application.Commands.Acquisitions;
using GTL.Application.DTO.Acquisitions.Command;
using GTL.Application.Queries.Acquisitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTL.API.Controllers
{
    [Route("api/acquisition")]
    [ApiController]
    public class AcquisitionController : BaseController
    {
        private IMapper _mapper;
        private IDispatcher _dispatcher;

        public AcquisitionController(IMapper mapper, IDispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAcquisition(CreateAcquisitionRequestDto request)
        {
            CreateAcquisitionRequestDto.Validator validator = new CreateAcquisitionRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                CreateAcquisitionCommand command = new CreateAcquisitionCommand(
                    request.MemberId,
                    request.ItemCatalogId,
                    request.RequestDate,
                    request.Amount
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAcquisitions()
        {
            GetAllAcquisitionsQuery query = new GetAllAcquisitionsQuery();
            var result = await _dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{memberId}/{itemCatalogId}/{requestDate}")]
        public async Task<IActionResult> GetAcquisition(Guid memberId, Guid itemCatalogId, DateTime requestDate)
        {
            var result = await _dispatcher.Dispatch(new GetAcquisitionQuery(memberId, itemCatalogId, requestDate));
            return FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAcquisition(UpdateAcquisitionRequestDto request)
        {
            UpdateAcquisitionRequestDto.Validator validator = new UpdateAcquisitionRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                UpdateAcquisitionCommand command = new UpdateAcquisitionCommand(
                    request.MemberId,
                    request.ItemCatalogId,
                    request.RequestDate,
                    request.Amount,
                    request.RowVersion
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAcquisition(DeleteAcquisitionRequestDto request)
        {
            DeleteAcquisitionRequestDto.Validator validator = new DeleteAcquisitionRequestDto.Validator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                DeleteAcquisitionCommand command = new DeleteAcquisitionCommand(
                    request.MemberId,
                    request.ItemCatalogId,
                    request.RequestDate
                    );
                var commandResult = await _dispatcher.Dispatch(command);
                return FromResult(commandResult);
            }
            return BadRequest(result.Errors);
        }
    }
}
