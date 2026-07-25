using BankManagementSystem.Enums;

namespace BankManagementSystem.Entities;

public class Account
{
    public string AccountNumber { get; set; } = null!;

    public AccountType AccountType { get; set; }

    public DateTime OpeningDate { get; set; }

    public decimal CurrentBalance { get; set; }

    public int BranchCode { get; set; }

    public Branch Branch { get; set; } = null!;

    public ICollection<CustomerAccount> CustomerAccounts
        = new List<CustomerAccount>();

    public ICollection<Transaction> Transactions
        = new List<Transaction>();
}
