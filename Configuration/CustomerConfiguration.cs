using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
               .HasMaxLength(100);

        builder.Property(x => x.Email)
               .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
               .HasMaxLength(20);

        builder.Property(x => x.NationalId)
               .HasMaxLength(14);

        builder.Property(x => x.Address)
               .HasMaxLength(250);
    }
}
