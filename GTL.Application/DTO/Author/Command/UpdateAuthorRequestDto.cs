using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Author.Command
{
    public class UpdateAuthorRequestDto
    {
        public Guid? ItemCatalogId { get; set; }
        public string CurrentName { get; set; }
        public string UpdatedName { get; set; }
        public byte[] RowVersion { get; set; }
        public class Validator : AbstractValidator<UpdateAuthorRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.CurrentName).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(CurrentName)).Code);
                RuleFor(r => r.UpdatedName).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(UpdatedName)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
                RuleFor(r => r.RowVersion).NotNull().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }   
    }
}
