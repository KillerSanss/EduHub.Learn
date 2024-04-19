using Eduhub.StudentService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Eduhub.StudentService.Infrastructure.Data.Extensions;

/// <summary>
/// Класс регистрации энамов в базе данных
/// </summary>
public static class ModelBuilderExtension
{
    /// <summary>
    /// Метод регистации
    /// </summary>
    public static void RegisterEnums(this ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Gender>();
    }
}