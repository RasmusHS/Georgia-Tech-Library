using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Acquisitions.Command
{
    public class UpdateAcquisitionRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }
        public byte[] RowVersion { get; set; }

        public class Validator : AbstractValidator<UpdateAcquisitionRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.RequestDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RequestDate)).Code);
                RuleFor(r => r.Amount).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Amount)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }
    }
}
