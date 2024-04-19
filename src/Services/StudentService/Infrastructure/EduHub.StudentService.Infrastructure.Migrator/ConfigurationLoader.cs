using Microsoft.Extensions.Configuration;

namespace EduHub.StudentService.Infrastructure.Migrator;

/// <summary>
/// Класс для загрузки кофига
/// </summary>
public static class ConfigurationLoader
{
    /// <summary>
    /// Метод загрузки конфика
    /// </summary>
    /// <returns>Конфиг.</returns>
    public static IConfiguration Load()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var localEnvironment = Environment.GetEnvironmentVariable("LOCAL_ENVIRONMENT");

        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables();

        if (!string.IsNullOrEmpty(localEnvironment))
        {
            configBuilder.AddJsonFile($"appsettings.local.{localEnvironment}.json", true, true);
        }

        return configBuilder.Build();
    }
}