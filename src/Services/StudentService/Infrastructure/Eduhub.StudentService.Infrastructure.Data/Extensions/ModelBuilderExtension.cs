using Eduhub.StudentService.Domain.Entities.Enums;
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
}