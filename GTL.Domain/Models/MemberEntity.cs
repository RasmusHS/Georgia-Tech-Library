using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class MemberEntity : BaseEntity
    {
        public MemberEntity()  {   }

        private MemberEntity(string name, string homeAddress, string? campusAddress, string phoneNumber, string email, string type, string ssn, string? employeePosition)
        {
            MemberId = Guid.NewGuid();
            Name = name;
            HomeAddress = homeAddress;
            CampusAddress = campusAddress;
            PhoneNumber = phoneNumber;
            Email = email;
            Type = type;
            SSN = ssn;
            CardExpirationDate = DateTime.Now.AddYears(4);
            EmployeePosition = employeePosition;
        }

        public static Result<MemberEntity> Create(string name, string homeAddress, string? campusAddress, string phoneNumber, string email, string type, string ssn, string? employeePosition)
        {
            Ensure.That(name, nameof(name)).IsNotNullOrEmpty();
            Ensure.That(homeAddress, nameof(homeAddress)).IsNotNullOrEmpty();
            Ensure.That(campusAddress, nameof(campusAddress));
            Ensure.That(phoneNumber, nameof(phoneNumber)).IsNotNullOrEmpty();
            Ensure.That(email, nameof(email)).IsNotNullOrEmpty();
            Ensure.That(type, nameof(type)).IsNotNullOrEmpty();
            Ensure.That(ssn, nameof(ssn)).IsNotNullOrEmpty();
            Ensure.That(employeePosition, nameof(employeePosition));
            return Result.Ok(new MemberEntity(name, homeAddress, campusAddress, phoneNumber, email, type, ssn, employeePosition));
        }

        public void Edit(string name, string homeAddress, string? campusAddress, string phoneNumber, string email, string type, string ssn, DateTime cardExpirationDate, string? employeePosition, byte[] rowVersion)
        {
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
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string? CampusAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string SSN { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public string? EmployeePosition { get; set; }

        public List<ItemBorrowingsEntity> Borrowings { get; private set; }
        public List<ReserveItemEntity> ReservedItems { get; private set; }
        public List<AcquisitionEntity> AcquisitionItems { get; private set; }
    }
}
