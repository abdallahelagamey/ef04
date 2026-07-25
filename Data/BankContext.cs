using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Data;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
    }
}
