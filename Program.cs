using BankManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddDbContext<BankContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));

var provider = services.BuildServiceProvider();

using var scope = provider.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<BankContext>();

context.Database.Migrate();

Console.WriteLine("Database Created Successfully.");
