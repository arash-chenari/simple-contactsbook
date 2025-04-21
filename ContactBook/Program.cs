using ContactBook.Controllers;
using ContactBook.Models;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton<ContactsController>()
            .AddDbContext<ApplicationDbContext>()
            .AddScoped<IContactRepository, EfContactsRepository>()
            .BuildServiceProvider();

        var contactsController = serviceCollection
            .GetRequiredService<ContactsController>();

        for(; ; )
        {
            Console.WriteLine("1)Add Contact  2)Search");
            var selectedItem = Console.ReadLine();

            switch (selectedItem)
            {
                case "1":
                    Console.WriteLine("Please enter FirstName");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Please enter LastName");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Please enter Email");
                    var email = Console.ReadLine();
                    Console.WriteLine("Please enter PhoneNumber");
                    var phoneNumber = Console.ReadLine();

                    var dto = new AddContactDto
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Phone = phoneNumber
                    };
                    contactsController.Add(dto);
                    break;
                case "2":
                    //search
                    break;
                default:
                    break;
            }
        }
    }
}