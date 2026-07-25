using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.TransactionNumber);

        builder.Property(x => x.Amount)
               .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Account)
               .WithMany(x => x.Transactions)
               .HasForeignKey(x => x.AccountNumber);
    }
}
