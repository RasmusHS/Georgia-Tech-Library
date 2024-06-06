using FluentValidation;
using GTL.Domain.Common;
namespace GTL.Application.DTO.ItemBorrowings.Command
{
    public class UpdateBorrowingRequestDto
    {
        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Due { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public class Validator : AbstractValidator<UpdateBorrowingRequestDto>
        {
            public Validator()
            {
                RuleFor(r => r.MemberId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(MemberId)).Code);
                RuleFor(r => r.ItemId).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ItemId)).Code);
                RuleFor(r => r.StartDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(StartDate)).Code);
                RuleFor(r => r.Due).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Due)).Code);
                //RuleFor(r => r.ReturnedDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(ReturnedDate)).Code);
                RuleFor(r => r.RowVersion).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(RowVersion)).Code);
            }
        }
    }
}
