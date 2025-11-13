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

    public class AddressBook
    {
        private readonly List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("\nContact added successfully!");
        }

        public Contact FindContactByName(string firstName, string lastName)
        {
            foreach (Contact c in contacts)
            {
                if (c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    return c;
                }
            }
            return null;
        }

        public void EditContactUsingConsole()
        {
            Console.Write("\nEnter First Name to edit: ");
            string first = Console.ReadLine();
            Console.Write("Enter Last Name to edit: ");
            string last = Console.ReadLine();

            Contact contact = FindContactByName(first, last);

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.Write("New Address: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Address = input;

            Console.Write("New City: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.City = input;

            Console.WriteLine("Contact updated!");
        }

        public void DeleteContactUsingConsole()
        {
            Console.Write("\nEnter First Name to delete: ");
            string first = Console.ReadLine();
            Console.Write("Enter Last Name to delete: ");
            string last = Console.ReadLine();

            Contact contact = FindContactByName(first, last);

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            contacts.Remove(contact);
            Console.WriteLine("Contact deleted!");
        }

        public void DisplayAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts in this Address Book.");
                return;
            }

            Console.WriteLine("\nContacts in this Address Book:");
            foreach (var c in contacts)
                c.Display();
        }

        public Contact CreateContactFromConsole()
        {
            Contact c = new Contact();

            Console.Write("\nFirst Name : "); c.FirstName = Console.ReadLine();
            Console.Write("Last Name  : "); c.LastName = Console.ReadLine();
            Console.Write("Address    : "); c.Address = Console.ReadLine();
            Console.Write("City       : "); c.City = Console.ReadLine();
            Console.Write("State      : "); c.State = Console.ReadLine();
            Console.Write("Zip        : "); c.Zip = Console.ReadLine();
            Console.Write("Phone      : "); c.Phone = Console.ReadLine();
            Console.Write("Email      : "); c.Email = Console.ReadLine();

            return c;
        }
    }

    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMAIN MENU...");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        Console.Write("\nEnter Address Book Name: ");
                        string name = Console.ReadLine();

                        if (addressBooks.ContainsKey(name))
                        {
                            Console.WriteLine("Address Book already exists!");
                        }
                        else
                        {
                            addressBooks[name] = new AddressBook();
                            Console.WriteLine("Address Book created!");
                        }
                        break;

                    case "2":
                        if (addressBooks.Count == 0)
                        {
                            Console.WriteLine("No Address Books available!");
                            break;
                        }

                        Console.WriteLine("\nAvailable Address Books:");
                        foreach (var ab in addressBooks.Keys)
                            Console.WriteLine("- " + ab);

                        Console.Write("\nEnter Address Book Name to open: ");
                        string selected = Console.ReadLine();

                        if (!addressBooks.ContainsKey(selected))
                        {
                            Console.WriteLine("Address Book not found!");
                            break;
                        }

                        AddressBook book = addressBooks[selected];
                        bool insideBook = true;

                        while (insideBook)
                        {
                            Console.WriteLine($"\nIn Address Book: {selected}");
                            Console.WriteLine("1. Add Contact");
                            Console.WriteLine("2. Edit Contact");
                            Console.WriteLine("3. Delete Contact");
                            Console.WriteLine("4. Display Contacts");
                            Console.WriteLine("5. Back to Main Menu");
                            Console.Write("Enter choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    book.AddContact(book.CreateContactFromConsole());
                                    break;
                                case "2":
                                    book.EditContactUsingConsole();
                                    break;
                                case "3":
                                    book.DeleteContactUsingConsole();
                                    break;
                                case "4":
                                    book.DisplayAllContacts();
                                    break;
                                case "5":
                                    insideBook = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
