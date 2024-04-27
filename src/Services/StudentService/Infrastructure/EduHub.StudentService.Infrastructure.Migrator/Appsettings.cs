using Microsoft.Extensions.Configuration;

namespace EduHub.StudentService.Infrastructure.Migrator;

/// <summary>
/// Класс для загрузки кофига
/// </summary>
public static class Appsettings
{
    /// <summary>
    /// Метод загрузки конфика
    /// </summary>
    /// <returns>Конфиг.</returns>
    public static IConfiguration Get()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddJsonFile("appsettings.local.json", true, true)
            .AddEnvironmentVariables();

        return configBuilder.Build();
    }
}