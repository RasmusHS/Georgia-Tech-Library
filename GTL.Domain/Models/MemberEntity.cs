﻿using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class MemberEntity : BaseEntity
    {
        public MemberEntity()  {   }

        private MemberEntity(string name, string homeAddress, string campusAddress, string phoneNumber, string email, string type, string ssn)
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
        }

        public static Result<MemberEntity> Create(string name, string homeAddress, string campusAddress, string phoneNumber, string email, string type, string ssn)
        {
            Ensure.That(name, nameof(name)).IsNotNullOrEmpty();
            Ensure.That(homeAddress, nameof(homeAddress)).IsNotNullOrEmpty();
            Ensure.That(campusAddress, nameof(campusAddress)).IsNotNullOrEmpty();
            Ensure.That(phoneNumber, nameof(phoneNumber)).IsNotNullOrEmpty();
            Ensure.That(email, nameof(email)).IsNotNullOrEmpty();
            Ensure.That(type, nameof(type)).IsNotNullOrEmpty();
            Ensure.That(ssn, nameof(ssn)).IsNotNullOrEmpty();
            return Result.Ok(new MemberEntity(name, homeAddress, campusAddress, phoneNumber, email, type, ssn));
        }

        public void Edit()
        {

        }

        public Guid MemberId { get; private set; }
        public string Name { get; private set; }
        public string HomeAddress { get; private set; }
        public string CampusAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Type { get; private set; }
        public string SSN { get; private set; }
        public DateTime CardExpirationDate { get; private set; }

        public List<BookBorrowingsEntity> Borrowings { get; private set; }
        public List<BookEntity> Books { get; private set; }

        
    }
}