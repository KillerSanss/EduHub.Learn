using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Infrastructure.Data;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories;
using EduHub.StudentService.Infrastructure.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests;

/// <summary>
/// Фикстура
/// </summary>
public class DatabaseFixture : IAsyncLifetime
{
    public IServiceProvider ServiceProvider;

    public async Task InitializeAsync()
    {
        var serviceCollection = new ServiceCollection();

        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");

        AddDbContext(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        using var scope = ServiceProvider.CreateScope();

        await MigrateDatabase(scope);
    }

    public async Task DisposeAsync()
    {
    }

    private static void AddDbContext(IServiceCollection serviceCollection)
    {
        var connectionString = "Host=localhost;Port=5432;Database=Student;Username=user;Password=password";

        serviceCollection.AddDbContext<StudentDbContext>(o => o
         .UseNpgsql(EduhubNpgsqlDataSource.Create(connectionString),
            builder => builder.MigrationsAssembly(typeof(Program).Assembly.FullName)));

        serviceCollection.AddScoped<IEducatorRepository, EducatorRepository>();
        serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork<StudentDbContext>>();
    }

    private static async Task MigrateDatabase(IServiceScope scope)
    {
        await using var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}