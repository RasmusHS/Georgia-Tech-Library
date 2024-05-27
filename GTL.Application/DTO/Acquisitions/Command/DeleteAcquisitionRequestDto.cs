using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.Acquisitions.Command
{
    public class DeleteAcquisitionRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }

        public class Validator : AbstractValidator<DeleteAcquisitionRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.RequestDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RequestDate)).Code);
            }
        }
    }
}
