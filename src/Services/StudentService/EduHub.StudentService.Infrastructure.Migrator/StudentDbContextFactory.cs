using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EduHub.StudentService.Infrastructure.Migrator;

/// <summary>
/// Фабрика для получения экземпляров контекста базы данных
/// </summary>
public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = ConfigurationLoader.Load();

        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                  ?? throw new ArgumentNullException(nameof(connectionString));

        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new StudentDbContext(optionsBuilder.Options);
    }
}