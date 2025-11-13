using System;
using System.Collections.Generic;

namespace Address_Book
{
    
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            
            Console.WriteLine($"Name   : {FirstName} {LastName}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"City   : {City}");
            Console.WriteLine($"State  : {State}");
            Console.WriteLine($"Zip    : {Zip}");
            Console.WriteLine($"Phone  : {Phone}");
            Console.WriteLine($"Email  : {Email}");
        }
    }

    // AddressBook uses a Collection (List<Contact>) to store MULTIPLE persons
    public class AddressBook
    {
        // ✅ Collection class as required by UC5
        private readonly List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("\nContact added successfully!\n");
        }

        public Contact FindContactByName(string firstName, string lastName)
        {
            foreach (var contact in contacts)
            {
                if (string.Equals(contact.FirstName, firstName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(contact.LastName, lastName, StringComparison.OrdinalIgnoreCase))
                {
                    return contact;
                }
            }
            return null;
        }

        public void EditContactUsingConsole()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts to edit.");
                return;
            }

            Console.Write("\nEnter First Name of contact to edit: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name of contact to edit : ");
            string lastName = Console.ReadLine();

            Contact contact = FindContactByName(firstName, lastName);

            if (contact == null)
            {
                Console.WriteLine("\nContact not found!");
                return;
            }

            Console.WriteLine("\nEnter new details (leave blank to keep old value):");

            Console.Write("First Name (" + contact.FirstName + "): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.FirstName = input;

            Console.Write("Last Name (" + contact.LastName + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.LastName = input;

            Console.Write("Address (" + contact.Address + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Address = input;

            Console.Write("City (" + contact.City + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.City = input;

            Console.Write("State (" + contact.State + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.State = input;

            Console.Write("Zip (" + contact.Zip + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Zip = input;

            Console.Write("Phone (" + contact.Phone + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Phone = input;

            Console.Write("Email (" + contact.Email + "): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Email = input;

            Console.WriteLine("\nContact updated successfully!");
        }

        public void DeleteContactUsingConsole()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts available to delete.");
                return;
            }

            Console.Write("\nEnter First Name of contact to delete: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name of contact to delete : ");
            string lastName = Console.ReadLine();

            Contact contact = FindContactByName(firstName, lastName);

            if (contact == null)
            {
                Console.WriteLine("\nContact not found!");
                return;
            }

            contacts.Remove(contact);
            Console.WriteLine("\nContact deleted successfully!");
        }

        public void DisplayAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("\nNo contacts to display.");
                return;
            }

            Console.WriteLine("\nAddress Book Contacts....");
            foreach (var contact in contacts)
            {
                contact.Display();
            }
        }

        
        public Contact CreateContactFromConsole()
        {
            Contact contact = new Contact();

            Console.Write("\nEnter First Name  : ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name   : ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Address     : ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City        : ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State       : ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip Code    : ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Enter Email       : ");
            contact.Email = Console.ReadLine();

            return contact;
        }
    }

    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program...");

            AddressBook addressBook = new AddressBook();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMENU....");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("2. Edit Existing Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // 👇 UC5: add multiple persons one by one by calling this again and again
                        Contact c = addressBook.CreateContactFromConsole();
                        addressBook.AddContact(c);
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for using Address Book. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
