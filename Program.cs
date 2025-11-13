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

        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Contact other = (Contact)obj;

            return FirstName.Equals(other.FirstName, StringComparison.OrdinalIgnoreCase) &&
                   LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }
    }

    public class AddressBook
    {
        private readonly List<Contact> contacts = new List<Contact>();

        
        public void AddContact(Contact contact)
        {
            bool duplicate = contacts.Exists(c => c.Equals(contact));

            if (duplicate)
            {
                Console.WriteLine("\nDuplicate Contact! Cannot Add.");
                return;
            }

            contacts.Add(contact);
            Console.WriteLine("\nContact added successfully!");
        }

        public Contact FindContactByName(string first, string last)
        {
            foreach (var c in contacts)
            {
                if (c.FirstName.Equals(first, StringComparison.OrdinalIgnoreCase) &&
                    c.LastName.Equals(last, StringComparison.OrdinalIgnoreCase))
                    return c;
            }
            return null;
        }

        public void EditContactUsingConsole()
        {
            Console.Write("\nEnter First Name to edit: ");
            string first = Console.ReadLine();
            Console.Write("Enter Last Name to edit : ");
            string last = Console.ReadLine();

            Contact contact = FindContactByName(first, last);

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.Write("New Address (leave blank to keep same): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Address = input;

            Console.Write("New City (leave blank to keep same): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.City = input;

            Console.Write("New State (leave blank to keep same): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.State = input;

            Console.Write("New Zip (leave blank to keep same): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Zip = input;

            Console.Write("New Phone (leave blank to keep same): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Phone = input;

            Console.Write("New Email (leave blank to keep same): ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) contact.Email = input;

            Console.WriteLine("Contact updated!");
        }

        public void DeleteContactUsingConsole()
        {
            Console.Write("\nEnter First Name to delete: ");
            string first = Console.ReadLine();
            Console.Write("Enter Last Name to delete : ");
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

            Console.WriteLine("\nContacts:");
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

        
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        
        public List<Contact> GetContactsByCity(string city)
        {
            List<Contact> results = new List<Contact>();
            foreach (var c in contacts)
            {
                if (!string.IsNullOrWhiteSpace(c.City) &&
                    c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(c);
                }
            }
            return results;
        }

        public List<Contact> GetContactsByState(string state)
        {
            List<Contact> results = new List<Contact>();
            foreach (var c in contacts)
            {
                if (!string.IsNullOrWhiteSpace(c.State) &&
                    c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(c);
                }
            }
            return results;
        }
    }

    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, AddressBook> addressBooks =
                new Dictionary<string, AddressBook>(StringComparer.OrdinalIgnoreCase);

            
            Dictionary<string, List<Contact>> cityPersons =
                new Dictionary<string, List<Contact>>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, List<Contact>> statePersons =
                new Dictionary<string, List<Contact>>(StringComparer.OrdinalIgnoreCase);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMAIN MENU...");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Search Person by City/State (Across All Address Books)");
                Console.WriteLine("4. View Persons by City/State (Using Dictionaries)");
                Console.WriteLine("5. Get Count of Persons by City/State");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        Console.Write("\nEnter Address Book Name: ");
                        string name = Console.ReadLine();

                        if (addressBooks.ContainsKey(name))
                            Console.WriteLine("Address Book already exists!");
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
                        bool inside = true;

                        while (inside)
                        {
                            Console.WriteLine($"\nAddress Book:{selected}");
                            Console.WriteLine("1. Add Contact");
                            Console.WriteLine("2. Edit Contact");
                            Console.WriteLine("3. Delete Contact");
                            Console.WriteLine("4. Display Contacts");
                            Console.WriteLine("5. Back");
                            Console.Write("Choice: ");

                            string c = Console.ReadLine();

                            switch (c)
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
                                    inside = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        break;

                    case "3":
                        
                        if (addressBooks.Count == 0)
                        {
                            Console.WriteLine("No Address Books available!");
                            break;
                        }

                        Console.WriteLine("\nSearch by:");
                        Console.WriteLine("1. City");
                        Console.WriteLine("2. State");
                        Console.Write("Enter choice: ");
                        string searchChoice = Console.ReadLine();

                        if (searchChoice == "1")
                        {
                            Console.Write("\nEnter City Name: ");
                            string city = Console.ReadLine();
                            SearchAcrossAllAddressBooksByCity(addressBooks, city);
                        }
                        else if (searchChoice == "2")
                        {
                            Console.Write("\nEnter State Name: ");
                            string state = Console.ReadLine();
                            SearchAcrossAllAddressBooksByState(addressBooks, state);
                        }
                        else
                        {
                            Console.WriteLine("Invalid search choice!");
                        }
                        break;

                    case "4":
                        
                        if (addressBooks.Count == 0)
                        {
                            Console.WriteLine("No Address Books available!");
                            break;
                        }

                        
                        RebuildCityStateDictionaries(addressBooks, cityPersons, statePersons);

                        Console.WriteLine("\nView persons by:");
                        Console.WriteLine("1. City");
                        Console.WriteLine("2. State");
                        Console.Write("Enter choice: ");
                        string viewChoice = Console.ReadLine();

                        if (viewChoice == "1")
                        {
                            ViewPersonsByCity(cityPersons);
                        }
                        else if (viewChoice == "2")
                        {
                            ViewPersonsByState(statePersons);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice!");
                        }
                        break;

                    case "5":
                        
                        if (addressBooks.Count == 0)
                        {
                            Console.WriteLine("No Address Books available!");
                            break;
                        }

                        
                        RebuildCityStateDictionaries(addressBooks, cityPersons, statePersons);

                        Console.WriteLine("\nGet count of persons by:");
                        Console.WriteLine("1. City");
                        Console.WriteLine("2. State");
                        Console.Write("Enter choice: ");
                        string countChoice = Console.ReadLine();

                        if (countChoice == "1")
                        {
                            CountPersonsByCity(cityPersons);
                        }
                        else if (countChoice == "2")
                        {
                            CountPersonsByState(statePersons);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice!");
                        }
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

            Console.WriteLine("\nGoodbye!");
        }

        

        private static void SearchAcrossAllAddressBooksByCity(
            Dictionary<string, AddressBook> addressBooks, string city)
        {
            int totalMatches = 0;

            foreach (var pair in addressBooks)
            {
                string abName = pair.Key;
                AddressBook ab = pair.Value;

                List<Contact> matches = ab.GetContactsByCity(city);

                if (matches.Count > 0)
                {
                    Console.WriteLine($"\nAddress Book: {abName}");
                    foreach (var contact in matches)
                    {
                        contact.Display();
                        totalMatches++;
                    }
                }
            }

            if (totalMatches == 0)
                Console.WriteLine("\nNo persons found in the given city.");
            else
                Console.WriteLine($"\nTotal persons found in city \"{city}\": {totalMatches}");
        }

        private static void SearchAcrossAllAddressBooksByState(
            Dictionary<string, AddressBook> addressBooks, string state)
        {
            int totalMatches = 0;

            foreach (var pair in addressBooks)
            {
                string abName = pair.Key;
                AddressBook ab = pair.Value;

                List<Contact> matches = ab.GetContactsByState(state);

                if (matches.Count > 0)
                {
                    Console.WriteLine($"\nAddress Book: {abName}");
                    foreach (var contact in matches)
                    {
                        contact.Display();
                        totalMatches++;
                    }
                }
            }

            if (totalMatches == 0)
                Console.WriteLine("\nNo persons found in the given state.");
            else
                Console.WriteLine($"\nTotal persons found in state \"{state}\": {totalMatches}");
        }

        

        private static void RebuildCityStateDictionaries(
            Dictionary<string, AddressBook> addressBooks,
            Dictionary<string, List<Contact>> cityDict,
            Dictionary<string, List<Contact>> stateDict)
        {
            cityDict.Clear();
            stateDict.Clear();

            foreach (var pair in addressBooks)
            {
                AddressBook ab = pair.Value;

                foreach (var contact in ab.GetAllContacts())
                {
                    if (!string.IsNullOrWhiteSpace(contact.City))
                    {
                        if (!cityDict.TryGetValue(contact.City, out var listByCity))
                        {
                            listByCity = new List<Contact>();
                            cityDict[contact.City] = listByCity;
                        }
                        listByCity.Add(contact);
                    }

                    if (!string.IsNullOrWhiteSpace(contact.State))
                    {
                        if (!stateDict.TryGetValue(contact.State, out var listByState))
                        {
                            listByState = new List<Contact>();
                            stateDict[contact.State] = listByState;
                        }
                        listByState.Add(contact);
                    }
                }
            }
        }

        private static void ViewPersonsByCity(Dictionary<string, List<Contact>> cityDict)
        {
            Console.Write("\nEnter City Name: ");
            string city = Console.ReadLine();

            if (cityDict.TryGetValue(city, out var list) && list.Count > 0)
            {
                Console.WriteLine($"\nPersons in city \"{city}\":");
                foreach (var contact in list)
                    contact.Display();

                Console.WriteLine($"\nTotal persons: {list.Count}");
            }
            else
            {
                Console.WriteLine("\nNo persons found in that city.");
            }
        }

        private static void ViewPersonsByState(Dictionary<string, List<Contact>> stateDict)
        {
            Console.Write("\nEnter State Name: ");
            string state = Console.ReadLine();

            if (stateDict.TryGetValue(state, out var list) && list.Count > 0)
            {
                Console.WriteLine($"\nPersons in state \"{state}\":");
                foreach (var contact in list)
                    contact.Display();

                Console.WriteLine($"\nTotal persons: {list.Count}");
            }
            else
            {
                Console.WriteLine("\nNo persons found in that state.");
            }
        }

        

        private static void CountPersonsByCity(Dictionary<string, List<Contact>> cityDict)
        {
            Console.Write("\nEnter City Name: ");
            string city = Console.ReadLine();

            if (cityDict.TryGetValue(city, out var list) && list.Count > 0)
            {
                Console.WriteLine($"\nNumber of persons in city \"{city}\": {list.Count}");
            }
            else
            {
                Console.WriteLine("\nNo persons found in that city.");
            }
        }

        private static void CountPersonsByState(Dictionary<string, List<Contact>> stateDict)
        {
            Console.Write("\nEnter State Name: ");
            string state = Console.ReadLine();

            if (stateDict.TryGetValue(state, out var list) && list.Count > 0)
            {
                Console.WriteLine($"\nNumber of persons in state \"{state}\": {list.Count}");
            }
            else
            {
                Console.WriteLine("\nNo persons found in that state.");
            }
        }
    }
}
