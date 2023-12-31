﻿using System;
namespace AddressBookLibrary
{
    public class Contact
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nPhone: {PhoneNumber}\nEmail: {Email}\nAddress: {Address}\n";
        }

    }
}
