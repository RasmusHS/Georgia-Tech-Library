﻿namespace GTL.Application.Commands.ItemBorrowings
{
    public class UpdateBorrowingCommand : ICommand
    {
        public UpdateBorrowingCommand(Guid memberId, Guid itemId, DateTime startDate, DateTime due, DateTime? returnedDate, byte[] rowVersion) 
        {
            MemberId = memberId;
            ItemId = itemId;
            StartDate = startDate;
            Due = due;
            ReturnedDate = returnedDate;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Due { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}