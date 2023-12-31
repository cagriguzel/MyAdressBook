using System.Collections.Generic;
using Xunit;
using AddressBookLibrary;

public class ContactServiceTests
{
    [Fact]
    public void AddContact_ShouldAddContact_WhenValidContactProvided()
    {
        // Arrange
        var contactService = new ContactService();
        var testContact = new Contact
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test@example.com",
            PhoneNumber = "123456789",
            Address = "Test Address"
        };

        // Act
        contactService.AddContact(testContact);

        // Assert
        var contacts = contactService.GetContacts();
        Assert.True(contacts.Any(c => c.Email == testContact.Email));
    }

    [Fact]
    public void GetContacts_ShouldReturnEmptyList_WhenNoContactsExist()
    {
        // Arrange
        var contactService = new ContactService();
        contactService.SaveContacts(new List<Contact>());

        // Act
        var contacts = contactService.GetContacts();

        // Assert
        Assert.Empty(contacts);
    }

   

    [Fact]
    public void UpdateContact_ShouldUpdateContact_WhenValidContactProvided()
    {
        // Arrange
        var contactService = new ContactService();
        var testContact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            PhoneNumber = "123456789",
            Address = "123 Main St"
        };

        // Act
        contactService.AddContact(testContact);

        // Perform the update without the using statement
        var updatedContactService = new ContactService();
        var updatedContact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            PhoneNumber = "987654321",
            Address = "456 Oak St"
        };

        updatedContactService.UpdateContact(updatedContact);

        // Assert
        var contacts = contactService.GetContacts();
        var resultContact = contacts.FirstOrDefault(c => c.Email == "john@example.com");
        Assert.NotNull(resultContact);
        Assert.Equal("987654321", resultContact.PhoneNumber);
        Assert.Equal("456 Oak St", resultContact.Address);
    }
}
