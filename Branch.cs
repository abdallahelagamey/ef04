namespace BankManagementSystem.Entities;

public class Branch
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    // One-To-One
    public Manager Manager { get; set; } = null!;

    // One-To-Many
    public ICollection<Account> Accounts { get; set; }
        = new List<Account>();
}
