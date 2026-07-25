using BankManagementSystem.Data;
using BankManagementSystem.Entities;
using BankManagementSystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Services;

public class AccountService
{
    private readonly BankContext _context;

    public AccountService(BankContext context)
    {
        _context = context;
    }

    public void OpenAccount()
    {
        Console.Write("Account Number: ");
        string accountNumber = Console.ReadLine()!;

        Console.WriteLine("1 Savings");
        Console.WriteLine("2 Current");
        Console.WriteLine("3 Business");

        AccountType accountType = (AccountType)(int.Parse(Console.ReadLine()!) - 1);

        Console.Write("Branch Code: ");
        int branchCode = int.Parse(Console.ReadLine()!);

        if (!_context.Branches.Any(b => b.Code == branchCode))
        {
            Console.WriteLine("Branch Not Found.");
            return;
        }

        Console.Write("Customer Id: ");
        int customerId = int.Parse(Console.ReadLine()!);

        if (!_context.Customers.Any(c => c.Id == customerId))
        {
            Console.WriteLine("Customer Not Found.");
            return;
        }

        Console.WriteLine("1 Primary Holder");
        Console.WriteLine("2 Co Holder");

        OwnershipType ownerType =
            Console.ReadLine() == "1"
                ? OwnershipType.PrimaryHolder
                : OwnershipType.CoHolder;

        var account = new Account
        {
            AccountNumber = accountNumber,
            AccountType = accountType,
            OpeningDate = DateTime.Now,
            CurrentBalance = 0,
            BranchCode = branchCode
        };

        _context.Accounts.Add(account);

        _context.CustomerAccounts.Add(new CustomerAccount
        {
            CustomerId = customerId,
            AccountNumber = accountNumber,
            OwnershipStartDate = DateTime.Now,
            OwnershipType = ownerType,
            AccountStatus = AccountStatus.Active
        });

        _context.SaveChanges();

        Console.WriteLine("Account Created.");
    }

    public void UpdateAccountStatus()
    {
        Console.Write("Account Number: ");
        string account = Console.ReadLine()!;

        Console.Write("Customer Id: ");
        int customerId = int.Parse(Console.ReadLine()!);

        var customerAccount = _context.CustomerAccounts
            .FirstOrDefault(x =>
                x.CustomerId == customerId &&
                x.AccountNumber == account);

        if (customerAccount == null)
        {
            Console.WriteLine("Relationship Not Found.");
            return;
        }

        customerAccount.AccountStatus =
            customerAccount.AccountStatus == AccountStatus.Active
                ? AccountStatus.Closed
                : AccountStatus.Active;

        _context.SaveChanges();

        Console.WriteLine("Status Updated.");
    }

    public void RemoveCustomerFromAccount()
    {
        Console.Write("Account Number: ");
        string account = Console.ReadLine()!;

        Console.Write("Customer Id: ");
        int customerId = int.Parse(Console.ReadLine()!);

        var relation = _context.CustomerAccounts
            .FirstOrDefault(x =>
                x.CustomerId == customerId &&
                x.AccountNumber == account);

        if (relation == null)
        {
            Console.WriteLine("Not Found.");
            return;
        }

        _context.CustomerAccounts.Remove(relation);

        _context.SaveChanges();

        Console.WriteLine("Removed Successfully.");
    }

    public void ListCustomers()
    {
        var customers = _context.Customers
            .Include(c => c.CustomerAccounts)
            .ThenInclude(ca => ca.Account)
            .ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"ID : {customer.Id}");
            Console.WriteLine($"Name : {customer.FullName}");
            Console.WriteLine($"Type : {customer.CustomerType}");

            foreach (var account in customer.CustomerAccounts)
            {
                Console.WriteLine($"   Account : {account.Account.AccountNumber}");
                Console.WriteLine($"   Balance : {account.Account.CurrentBalance}");
                Console.WriteLine($"   Status : {account.AccountStatus}");
                Console.WriteLine($"   Ownership : {account.OwnershipType}");
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}
