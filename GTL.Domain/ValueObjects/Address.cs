﻿using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        private Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }

        public Address() { } //for ORM

        public static Result<Address> Create(string street, string city, string zipcode)
        {
            Ensure.That(street, nameof(street)).IsNotNullOrEmpty();
            Ensure.That(city, nameof(city)).IsNotNullOrEmpty();
            Ensure.That(zipcode, nameof(zipcode)).IsNotNullOrEmpty();
            return Result.Ok(new Address(street, city, zipcode));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
