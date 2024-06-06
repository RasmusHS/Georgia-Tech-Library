using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.ReserveItem.Command
{
    public class DeleteReservationRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }

        public class Validator : AbstractValidator<DeleteReservationRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
            }
        }
    }
}
