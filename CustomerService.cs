using BankManagementSystem.Data;
using BankManagementSystem.Entities;
using BankManagementSystem.Enums;

namespace BankManagementSystem.Services;

public class CustomerService
{
    private readonly BankContext _context;

    public CustomerService(BankContext context)
    {
        _context = context;
    }

    public void AddCustomer()
    {
        Console.Write("Full Name: ");
        string fullName = Console.ReadLine()!;

        Console.Write("National ID: ");
        string nationalId = Console.ReadLine()!;

        Console.Write("Date Of Birth (yyyy-mm-dd): ");
        DateTime dob = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("Address: ");
        string address = Console.ReadLine()!;

        Console.WriteLine("Customer Type");
        Console.WriteLine("1. Individual");
        Console.WriteLine("2. Business");

        CustomerType type =
            Console.ReadLine() == "1"
                ? CustomerType.Individual
                : CustomerType.Business;

        var customer = new Customer
        {
            FullName = fullName,
            NationalId = nationalId,
            DateOfBirth = dob,
            Email = email,
            PhoneNumber = phone,
            Address = address,
            CustomerType = type
        };

        _context.Customers.Add(customer);

        _context.SaveChanges();

        Console.WriteLine("Customer Added Successfully.");
    }
}
