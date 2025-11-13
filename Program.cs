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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program...");
            Console.WriteLine("Create a new contact\n");

            Contact contact = new Contact();

            Console.Write("Enter First Name  : ");
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

            
            contact.Display();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
