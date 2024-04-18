using EduHub.StudentService.Infrastructure.Migrator;
using Microsoft.EntityFrameworkCore;

var dbContextFactory = new StudentDbContextFactory();

var dbContext = dbContextFactory.CreateDbContext([]);

var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

var migrations = pendingMigrations.ToList();

if (migrations.Any())
{
    Console.WriteLine("Был запущен метод Migrate.");
    Console.WriteLine("Примененные миграции:");

    foreach (var migration in migrations)
    {
        Console.WriteLine($"{migration}");
    }

    await dbContext.Database.MigrateAsync();
}
else
{
    Console.WriteLine("Нет примененных миграций.");
}