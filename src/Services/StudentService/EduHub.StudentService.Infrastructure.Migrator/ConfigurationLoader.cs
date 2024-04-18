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
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.local.json"), true);

        return configBuilder.Build();
    }
}