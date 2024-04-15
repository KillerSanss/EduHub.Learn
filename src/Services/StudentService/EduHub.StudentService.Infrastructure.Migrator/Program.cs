using EduHub.StudentService.Infrastructure.Migrator;
using Microsoft.EntityFrameworkCore;

var dbContextFactory = new StudentDbContextFactory();

var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());

var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

if (pendingMigrations.Any())
{
    await dbContext.Database.MigrateAsync();
}

