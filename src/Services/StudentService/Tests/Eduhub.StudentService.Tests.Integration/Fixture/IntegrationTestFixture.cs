using EduHub.StudentService.Application.Services;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using EduHub.StudentService.Application.Services.Mapping;
using EduHub.StudentService.Application.Services.Services;
using Eduhub.StudentService.Infrastructure.Data;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Migrator;
using EduHub.StudentService.Infrastructure.Repositories;
using EduHub.StudentService.Infrastructure.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;

/// <summary>
/// Фикстура
/// </summary>
public class IntegrationTestFixture : IAsyncLifetime
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

    /// <summary>
    /// Удаление базы после тестов
    /// </summary>
    public async Task DisposeAsync()
    {
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

        await dbContext.Database.EnsureDeletedAsync();
    }

    private static void AddDbContext(IServiceCollection serviceCollection)
    {
        var configuration = Appsettings.Get();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<StudentDbContext>(o => o
            .UseNpgsql(EduhubNpgsqlDataSource.Create(connectionString),
                builder => builder.MigrationsAssembly(typeof(StudentDbContextFactory).Assembly.FullName))
            .EnableServiceProviderCaching(false));

        AddServices(serviceCollection);
        ConfigureServices(serviceCollection, configuration);
    }

    private static async Task MigrateDatabase(IServiceScope scope)
    {
        await using var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var mySection = configuration.GetSection(nameof(MinioSettings));
        services.Configure<MinioSettings>(c => mySection.Bind(c));
    }

    private static void AddServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEducatorRepository, EducatorRepository>();
        serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
        serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
        serviceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork<StudentDbContext>>();
        serviceCollection.AddScoped<ICourseService, CourseService>();
        serviceCollection.AddScoped<IEducatorService, EducatorService>();
        serviceCollection.AddScoped<IStudentService, EduHub.StudentService.Application.Services.Services.StudentService>();
        serviceCollection.AddScoped<IEnrollmentService, EnrollmentService>();
        serviceCollection.AddScoped<IFormFile, FormFile>();
        serviceCollection.AddScoped<FileClient>();
        serviceCollection.AddScoped<TestFileClient>();
        serviceCollection.AddScoped<FileGetter>();
        serviceCollection.AddAutoMapper(typeof(CourseMappingProfile));
        serviceCollection.AddAutoMapper(typeof(EducatorMappingProfile));
        serviceCollection.AddAutoMapper(typeof(StudentMappingProfile));
        serviceCollection.AddAutoMapper(typeof(EnrollmentMappingProfile));
    }
}