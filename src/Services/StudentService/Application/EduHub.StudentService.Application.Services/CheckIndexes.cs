using EduHub.StudentService.Application.Services.Exceptions;
using Eduhub.StudentService.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Класс проверки сущность на уникальность
/// </summary>
/// <typeparam name="TEntity">Сущность.</typeparam>
public static class CheckIndexes<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Метод проверки
    /// </summary>
    /// <param name="ex">Исключение бд.</param>
    /// <param name="entity">Сущнсоть для проверки.</param>
    /// <param name="property">Параметр для проверки.</param>
    /// <param name="index">Индекс.</param>
    /// <exception cref="EntityConflictException{TEntity}">Исключение конфликта.</exception>
    public static void Check(DbUpdateException ex, TEntity entity, Func<TEntity, string> property, string index)
    {
        if (ex.InnerException is PostgresException innerException && innerException.Message.Contains(index))
        {
            throw new EntityConflictException<TEntity>(property(entity), property(entity));
        }
    }
}