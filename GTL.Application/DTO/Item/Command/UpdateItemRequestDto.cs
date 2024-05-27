using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Item.Command
{
    public class UpdateItemRequestDto
    {
        public Guid ItemId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public bool IsLendable { get; set; }
        public DateTime DateCreated { get; set; }
        public string Condition { get; set; }
        public byte[] RowVersion { get; set; }

        public class Validator : AbstractValidator<UpdateItemRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.ItemId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.IsLendable).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(IsLendable)).Code);
                RuleFor(r => r.DateCreated).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(DateCreated)).Code);
                RuleFor(r => r.Condition).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Condition)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
                RuleFor(r => r.RowVersion).NotNull().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }
    }
}
