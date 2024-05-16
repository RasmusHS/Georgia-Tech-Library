using FluentValidation;
using GTL.Domain.Common;
using GTL.Domain.ValueObjects;

namespace GTL.Application.DTO.Member.Command
{
    public class CreateMemberRequest
    {
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string? CampusAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string SSN { get; set; }
        public string? EmployeePosition { get; set; }

        public class Validator : AbstractValidator<CreateMemberRequest>
        {
            public Validator() 
            {
                RuleFor(r => r.Name).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Name)).Code);
                RuleFor(r => r.Email).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Email)).Code);
                RuleFor(r => r.Email).EmailAddress().WithMessage(Errors.General.UnexpectedValue(nameof(Email)).Code);
            }
        }
    }
}
