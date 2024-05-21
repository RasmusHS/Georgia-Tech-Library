using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Author.Command
{
    public class CreateAuthorRequestDto
    {
        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
        //public Guid? ItemCatalogId { get; set; }

        public class Validator : AbstractValidator<CreateAuthorRequestDto>
        {
            public Validator()
            {
                //RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.Name).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Name)).Code);
            }
        }
    }
}
