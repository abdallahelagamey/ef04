using BankManagementSystem.Enums;

namespace BankManagementSystem.Entities;

public class CustomerAccount
{
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public Account Account { get; set; } = null!;

    public DateTime OwnershipStartDate { get; set; }

    public OwnershipType OwnershipType { get; set; }

    public AccountStatus AccountStatus { get; set; }
}
