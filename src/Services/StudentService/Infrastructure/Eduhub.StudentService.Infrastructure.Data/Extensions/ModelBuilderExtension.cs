using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Eduhub.StudentService.Infrastructure.Data.Extensions;

/// <summary>
/// Класс расширение для modelBuilder
/// </summary>
public static class ModelBuilderExtension
{
    /// <summary>
    /// Метод регистации энамов
    /// </summary>
    public static void RegisterEnums(this ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Gender>();
    }

    /// <summary>
    /// Метод применения всех конфигураций
    /// </summary>
    public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducatorConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnrollmentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
    }
}