namespace GTL.Application.Commands.Member
{
    public class UpdateMemberCommand : ICommand
    {
        public UpdateMemberCommand(Guid memberId, string name, string homeAddress, string? campusAddress, string phoneNumber, string email, string type, string ssn, DateTime cardExpirationDate, string? employeePosition, byte[] rowVersion) 
        {
            MemberId = memberId;
            Name = name;
            HomeAddress = homeAddress;
            CampusAddress = campusAddress;
            PhoneNumber = phoneNumber;
            Email = email;
            Type = type;
            SSN = ssn;
            CardExpirationDate = cardExpirationDate;
            EmployeePosition = employeePosition;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; set; }
        public string Name { get; private set; }
        public string HomeAddress { get; private set; }
        public string? CampusAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Type { get; private set; }
        public string SSN { get; private set; }
        public DateTime CardExpirationDate { get; private set; }
        public string? EmployeePosition { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
