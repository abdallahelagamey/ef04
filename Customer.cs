using BankManagementSystem.Enums;

namespace BankManagementSystem.Entities;

public class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string NationalId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public CustomerType CustomerType { get; set; }

    public ICollection<CustomerAccount> CustomerAccounts
        = new List<CustomerAccount>();
}
