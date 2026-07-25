using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Configurations;

public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
{
    public void Configure(EntityTypeBuilder<CustomerAccount> builder)
    {
        builder.HasKey(x => new
        {
            x.CustomerId,
            x.AccountNumber
        });

        builder.HasOne(x => x.Customer)
               .WithMany(x => x.CustomerAccounts)
               .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Account)
               .WithMany(x => x.CustomerAccounts)
               .HasForeignKey(x => x.AccountNumber);
    }
}
