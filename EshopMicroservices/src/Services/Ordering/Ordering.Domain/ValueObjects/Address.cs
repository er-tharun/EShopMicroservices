using System;

using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        protected Address() {}
        private Address(string firstName, 
            string lastName, 
            string? email, 
            string addressLine, 
            string country, 
            string state, 
            string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipcode;
        }

        public static Address Of(string firstName,
            string lastName,
            string? email,
            string addressLine,
            string country,
            string state,
            string zipcode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine, nameof(addressLine));
            ArgumentException.ThrowIfNullOrWhiteSpace(country, nameof(country));
            ArgumentException.ThrowIfNullOrWhiteSpace(state, nameof(state));
            ArgumentException.ThrowIfNullOrWhiteSpace(zipcode, nameof(country));

            return new Address(firstName,
            lastName,
            email,
            addressLine,
            country,
            state,
            zipcode);
        }
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;
    }
}
