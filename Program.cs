using BankManagementSystem.Data;
using BankManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddDbContext<BankContext>(options =>
{
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"));
});

services.AddScoped<CustomerService>();
services.AddScoped<AccountService>();
services.AddScoped<TransactionService>();

var provider = services.BuildServiceProvider();

using var scope = provider.CreateScope();

var customerService =
    scope.ServiceProvider.GetRequiredService<CustomerService>();

var accountService =
    scope.ServiceProvider.GetRequiredService<AccountService>();

var transactionService =
    scope.ServiceProvider.GetRequiredService<TransactionService>();

bool exit = false;

while (!exit)
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("      BANK MANAGEMENT SYSTEM");
    Console.WriteLine("========================================");

    Console.WriteLine("1. Add New Customer");
    Console.WriteLine("2. Open New Account");
    Console.WriteLine("3. Update Account Status");
    Console.WriteLine("4. Remove Account From Customer");
    Console.WriteLine("5. List Customers");
    Console.WriteLine("6. Deposit");
    Console.WriteLine("7. Withdraw");
    Console.WriteLine("0. Exit");

    Console.WriteLine("----------------------------------------");

    Console.Write("Choose Option : ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid Input.");
        Console.ReadKey();
        continue;
    }

    Console.Clear();

    switch (choice)
    {
        case 1:
            customerService.AddCustomer();
            break;

        case 2:
            accountService.OpenAccount();
            break;

        case 3:
            accountService.UpdateAccountStatus();
            break;

        case 4:
            accountService.RemoveCustomerFromAccount();
            break;

        case 5:
            accountService.ListCustomers();
            break;

        case 6:

            Console.Write("Account Number : ");
            string depositAccount = Console.ReadLine()!;

            Console.Write("Amount : ");
            decimal depositAmount = decimal.Parse(Console.ReadLine()!);

            transactionService.AddTransaction(
                depositAccount,
                depositAmount,
                Enums.TransactionType.Deposit,
                "Cash Deposit");

            Console.WriteLine("Deposit Completed.");

            break;

        case 7:

            Console.Write("Account Number : ");
            string withdrawAccount = Console.ReadLine()!;

            Console.Write("Amount : ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine()!);

            transactionService.AddTransaction(
                withdrawAccount,
                withdrawAmount,
                Enums.TransactionType.Withdrawal,
                "Cash Withdrawal");

            Console.WriteLine("Withdrawal Completed.");

            break;

        case 0:
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid Choice.");
            break;
    }

    if (!exit)
    {
        Console.WriteLine();
        Console.WriteLine("Press Any Key To Continue...");
        Console.ReadKey();
    }
}
