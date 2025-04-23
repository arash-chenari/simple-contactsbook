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
            Console.WriteLine("1)Add Contact  2)Search 3)Update");
            var selectedItem = Console.ReadLine();

            switch (selectedItem)
            {
                case "1":
                    {
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
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter FirstName");
                    var InputText = Console.ReadLine();
                    var contacts = contactsController.FindByName(InputText);
                    
                    foreach(var contact in contacts)
                    {
                        Console.WriteLine($"Id: {contact.Id} " +
                            $"FirstName: {contact.FirstName}" +
                            $"LastName: {contact.LastName}" +
                            $"Phone: {contact.PhoneNumber}" +
                            $"Email: {contact.Email}");
                        Console.WriteLine("-----------------------------------");
                    }

                    break;
                case "3":
                    {
                        Console.WriteLine("Please enter Contact id");
                        var id = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WriteLine("Please enter FirstName");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Please enter LastName");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Please enter Email");
                        var email = Console.ReadLine();
                        Console.WriteLine("Please enter PhoneNumber");
                        var phoneNumber = Console.ReadLine();

                        var updateDto = new UpdateContactDto
                        {
                            Id = id,
                            Email = email,
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phoneNumber
                        };

                        contactsController.Update(updateDto);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}