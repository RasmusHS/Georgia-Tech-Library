namespace GTL.Application.DTO.Member.Query
{
    public class QueryMemberDto
    {
        public QueryMemberDto(Guid memberId, string name, string homeAddress, string? campusAddress, string phoneNumber, string email, string type, string ssn, DateTime cardExpirationDate, string? employeePosition)
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
        }

        public QueryMemberDto() { }

        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string? CampusAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string SSN { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public string? EmployeePosition { get; set; }
    }
}
