using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

/// <summary>
/// Класс для тестовой фабрики базы данных
/// </summary>
public class TestDbContextFactory : IDisposable
{
    private readonly DbContextOptions<StudentDbContext> _options;
    private bool _isDisposed;

    public TestDbContextFactory()
    {
        _options = new DbContextOptionsBuilder<StudentDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=Student;Username=user;Password=password")
            .Options;
    }

    public StudentDbContext CreateContext()
    {
        var context = new StudentDbContext(_options);
        return context;
    }

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
        }
    }
}