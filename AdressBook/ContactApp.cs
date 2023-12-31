using AddressBookLibrary;
using System;

namespace AddressBook
{
    /// <summary>
    /// Represents the main application for managing contacts.
    /// </summary>
    public class ContactApp
    {
        private readonly ContactService _contactService;

        /// <summary>
        /// Initializes a new instance of the ContactApp class.
        /// </summary>
        public ContactApp()
        {
            _contactService = new ContactService();
        }

        /// <summary>
        /// Runs the main loop of the contact management application.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                DisplayMainMenu();

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowContacts();
                        break;
                    case "2":
                        AddContact();
                        break;
                    case "3":
                        EditContacts();
                        break;
                    case "4":
                        RemoveContact();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Displays the main menu options.
        /// </summary>
        private void DisplayMainMenu()
        {
            Console.WriteLine("***** Address Book *****");
            Console.WriteLine("1. Show Contacts");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Edit Contacts");
            Console.WriteLine("4. Remove Contact (by Email)");
            Console.WriteLine("5. Exit");
        }

        /// <summary>
        /// Shows the list of contacts.
        /// </summary>
        private void ShowContacts()
        {
            var contacts = _contactService.GetContacts();

            Console.WriteLine("***** Contacts *****");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        /// <summary>
        /// Adds a new contact to the address book.
        /// </summary>
        private void AddContact()
        {
            Console.Write("Enter the first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Enter the last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            var phoneNumber = Console.ReadLine();

            Console.Write("Enter the email address: ");
            var email = Console.ReadLine();

            Console.Write("Enter the address: ");
            var address = Console.ReadLine();

            var newContact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address
            };

            _contactService.AddContact(newContact);

            Console.WriteLine("Contact added successfully.");
        }

        /// <summary>
        /// Placeholder for future implementation of contact editing.
        /// </summary>
        private void EditContacts()
        {
            Console.WriteLine("Edit Contacts functionality not implemented yet.");
        }

        /// <summary>
        /// Removes a contact by email address from the address book.
        /// </summary>
        private void RemoveContact()
        {
            Console.Write("Enter the email address to remove a contact: ");
            var email = Console.ReadLine();

            _contactService.RemoveContactByEmail(email);
            Console.WriteLine($"Contact with email '{email}' has been removed.");
        }
    }
}
