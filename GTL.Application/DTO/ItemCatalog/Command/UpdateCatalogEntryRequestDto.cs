using FluentValidation;
using GTL.Application.DTO.Author.Command;
using GTL.Domain.Common;

namespace GTL.Application.DTO.ItemCatalog.Command
{
    public class UpdateCatalogEntryRequestDto
    {
        public Guid ItemCatalogId { get; set; }
        public string? ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubjectArea { get; set; }
        public string Type { get; set; }
        public string? Edition { get; set; }
        public byte[] RowVersion { get; set; }

        public class Validator : AbstractValidator<UpdateCatalogEntryRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.Title).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Title)).Code);
                RuleFor(r => r.Description).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Description)).Code);
                RuleFor(r => r.SubjectArea).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(SubjectArea)).Code);
                RuleFor(r => r.Type).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Type)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
                RuleFor(r => r.RowVersion).NotNull().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }
    }
}
