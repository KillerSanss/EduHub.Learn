// See https://aka.ms/new-console-template for more information

using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>()
    .UseNpgsql(config.GetConnectionString("Server=localhost;Port=5432;Database=Student;User Id=user;Password=password;"));

using var dbContext = new StudentDbContext(optionsBuilder.Options);
dbContext.Database.Migrate();