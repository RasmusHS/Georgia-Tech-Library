using GTL.Application.DTO.Author.Command;
using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.ItemCatalog.Command
{
    public class CreateCatalogEntryWithAuthorsRequestDto
    {
        public string? ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubjectArea { get; set; }
        public string Type { get; set; }
        public string? Edition { get; set; }
        public List<CreateAuthorRequestDto> Authors { get; set; }

        public class Validator : AbstractValidator<CreateCatalogEntryWithAuthorsRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.Title).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Title)).Code);
                RuleFor(r => r.Description).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Description)).Code);
                RuleFor(r => r.SubjectArea).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(SubjectArea)).Code);
                RuleFor(r => r.Type).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Type)).Code);
                RuleForEach(r => r.Authors).SetValidator(new CreateAuthorRequestDto.Validator());
            }
        }
    }
}
