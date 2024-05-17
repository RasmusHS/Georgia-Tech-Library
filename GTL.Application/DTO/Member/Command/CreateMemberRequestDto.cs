using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Member.Command
{
    public class CreateMemberRequestDto
    {
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string? CampusAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string SSN { get; set; }
        public string? EmployeePosition { get; set; }

        public class Validator : AbstractValidator<CreateMemberRequestDto>
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
