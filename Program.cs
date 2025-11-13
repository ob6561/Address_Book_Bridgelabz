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
            Console.WriteLine("\nContact added successfully!\n");
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
    }
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program...");

            AddressBook addressBook = new AddressBook();
            string choice;

            do
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

                // Add to AddressBook (UC2 requirement)
                addressBook.AddContact(contact);

                Console.Write("\nDo you want to add another contact? (y/n): ");
                choice = Console.ReadLine();

            } while (choice.Equals("y", StringComparison.OrdinalIgnoreCase));

            // Show all contacts before exiting
            addressBook.DisplayAllContacts();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}
