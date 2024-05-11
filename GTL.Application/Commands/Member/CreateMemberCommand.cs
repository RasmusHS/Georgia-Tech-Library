namespace GTL.Application.Commands.Member
{
    public class CreateMemberCommand : ICommand
    {
        public CreateMemberCommand(string name, string homeAddress, string campusAddress, string phoneNumber, string email, string type, string ssn)
        {
            Name = name;
            HomeAddress = homeAddress;
            CampusAddress = campusAddress;
            PhoneNumber = phoneNumber;
            Email = email;
            Type = type;
            SSN = ssn;
        }

        public string Name { get; }
        public string HomeAddress { get; }
        public string CampusAddress { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Type { get; }
        public string SSN { get; }
    }
}
