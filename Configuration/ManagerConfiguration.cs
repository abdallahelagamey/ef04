using BankManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
               .HasMaxLength(100);

        builder.Property(x => x.Email)
               .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
               .HasMaxLength(20);

        builder.HasOne(x => x.Branch)
               .WithOne(x => x.Manager)
               .HasForeignKey<Manager>(x => x.BranchCode);

        builder.HasData(

            new Manager
            {
                Id = 1,
                FullName = "Ahmed Hassan",
                Email = "ahmed@bank.com",
                PhoneNumber = "01111111111",
                HireDate = new DateTime(2021,1,1),
                BranchCode = 1
            },

            new Manager
            {
                Id = 2,
                FullName = "Sara Mohamed",
                Email = "sara@bank.com",
                PhoneNumber = "01222222222",
                HireDate = new DateTime(2022,1,1),
                BranchCode = 2
            }

        );
    }
}
