using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Migrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var config = ConfigurationLoader.Load();

var services = new ServiceCollection();

services.AddDbContext<StudentDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

await using var serviceProvider = services.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<StudentDbContext>();

var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>()
    .UseNpgsql(config.GetConnectionString("DefaultConnection"));

await using var db = new StudentDbContext(optionsBuilder.Options);

var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

if (pendingMigrations.Any())
{
    await dbContext.Database.MigrateAsync();
}