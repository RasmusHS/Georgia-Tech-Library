using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.ReserveItem.Command
{
    public class UpdateReservationRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime DateReserved { get; set; }
        public int Amount { get; set; }
        public byte[] RowVersion { get; set; }

        public class Validator : AbstractValidator<UpdateReservationRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemCatalogId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemCatalogId)).Code);
                RuleFor(r => r.DateReserved).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(DateReserved)).Code);
                RuleFor(r => r.Amount).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Amount)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }
    }
}
