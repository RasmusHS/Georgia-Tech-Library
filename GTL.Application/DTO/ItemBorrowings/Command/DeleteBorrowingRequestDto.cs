using FluentValidation;
using GTL.Domain.Common;

namespace GTL.Application.DTO.ItemBorrowings.Command
{
    public class DeleteBorrowingRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }

        public class Validator : AbstractValidator<DeleteBorrowingRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemId)).Code);
                RuleFor(r => r.StartDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(StartDate)).Code);
            }
        }
    }
}
