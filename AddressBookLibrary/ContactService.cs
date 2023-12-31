using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AddressBookLibrary
{
    /// <summary>
    /// Handles operations related to contacts, such as retrieval, addition, removal, and updating.
    /// </summary>
    public class ContactService
    {
        // File path to store contacts in JSON format
        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/contacts.json");

        /// <summary>
        /// Retrieves contacts from the JSON file.
        /// </summary>
        /// <returns>A list of contacts.</returns>
        public List<Contact> GetContacts()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    // Deserialize JSON directly into a List<Contact> or return an empty list if deserialization fails
                    return JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
                }
                catch (JsonSerializationException ex)
                {
                    // Handle deserialization exception and return an empty list
                    Console.WriteLine($"Error during deserialization: {ex.Message}");
                    return new List<Contact>();
                }
            }

            // Return an empty list if the file doesn't exist
            return new List<Contact>();
        }

        /// <summary>
        /// Saves contacts to the JSON file.
        /// </summary>
        /// <param name="contacts">The list of contacts to be saved.</param>
        public void SaveContacts(List<Contact> contacts)
        {
            // Get the directory of the file
            var directory = Path.GetDirectoryName(FilePath);

            // If the directory doesn't exist, create it
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Use 'using' to ensure proper disposal of resources
            using (var streamWriter = new StreamWriter(FilePath, false))
            {
                try
                {
                    // Serialize contacts to JSON with an indented format and write to the file
                    var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                    streamWriter.Write(json);
                }
                catch (JsonException ex)
                {
                    // Handle the error if it occurs during JSON serialization
                    Console.WriteLine($"JSON serialization error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Removes a contact by email address.
        /// </summary>
        /// <param name="email">The email address of the contact to be removed.</param>
        public void RemoveContactByEmail(string email)
        {
            var contacts = GetContacts();
            var contactToRemove = contacts.Find(c => c.Email == email);

            if (contactToRemove != null)
            {
                // Remove the specified contact and save the updated list
                contacts.Remove(contactToRemove);
                SaveContacts(contacts);
            }
        }

        /// <summary>
        /// Adds a new contact.
        /// </summary>
        /// <param name="newContact">The new contact to be added.</param>
        public void AddContact(Contact newContact)
        {
            var contacts = GetContacts();
            contacts.Add(newContact);

            // Save the updated list with the new contact
            SaveContacts(contacts);
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="updatedContact">The updated information for the existing contact.</param>
        public void UpdateContact(Contact updatedContact)
        {
            var contacts = GetContacts();
            var existingContact = contacts.Find(c => c.Email == updatedContact.Email);

            if (existingContact != null)
            {
                // Update the existing contact's information and save the updated list
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
                existingContact.Address = updatedContact.Address;

                SaveContacts(contacts);
            }
        }
    }
}
