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
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .Build();
    }
}