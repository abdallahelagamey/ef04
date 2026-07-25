using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(x => x.Code);

        builder.Property(x => x.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Address)
               .HasMaxLength(250);

        builder.Property(x => x.PhoneNumber)
               .HasMaxLength(20);

        builder.HasMany(x => x.Accounts)
               .WithOne(x => x.Branch)
               .HasForeignKey(x => x.BranchCode);

        builder.HasData(

            new Branch
            {
                Code = 1,
                Name = "Cairo Branch",
                Address = "Nasr City",
                PhoneNumber = "01000000001"
            },

            new Branch
            {
                Code = 2,
                Name = "Alex Branch",
                Address = "Smouha",
                PhoneNumber = "01000000002"
            }

        );
    }
}
