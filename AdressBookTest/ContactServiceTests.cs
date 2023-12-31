using System.Collections.Generic;
using NUnit.Framework;
using AddressBookLibrary;


namespace AddressBookLibrary.Tests
{
    [TestFixture]
    public class ContactServiceTests
    {
        [Test]
        public void RemoveContactByEmail_ShouldRemoveContact_WhenEmailExists()
        {
            // Arrange
            var contactService = new ContactService();
            var testContacts = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Contact { FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" },
            };

            contactService.SaveContacts(testContacts);

            // Act
            contactService.RemoveContactByEmail("jane@example.com");

            // Assert
            var remainingContacts = contactService.GetContacts();
            Assert.AreEqual(1, remainingContacts.Count);
            Assert.AreEqual("john@example.com", remainingContacts[0].Email);
        }
    }
}