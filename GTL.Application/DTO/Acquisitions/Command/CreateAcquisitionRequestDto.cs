using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Acquisitions.Command
{
    public class CreateAcquisitionRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }

        public class Validator : AbstractValidator<CreateAcquisitionRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.RequestDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RequestDate)).Code);
                RuleFor(r => r.Amount).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Amount)).Code);
            }
        }
    }
}
