using FluentValidation;
using GTL.Domain.Common;
using GTL.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Application.DTO.Member.Command
{
    public class CreateMemberRequest
    {
        public string Name { get; }
        public string HomeAddress { get; }
        public string CampusAddress { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Type { get; }
        public string SSN { get; }

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
