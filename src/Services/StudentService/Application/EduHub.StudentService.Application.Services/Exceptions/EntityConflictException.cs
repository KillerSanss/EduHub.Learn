using EduHub.StudentService.Application.Services.Exceptions.Base;
using Eduhub.StudentService.Domain.Entities.Base;

namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение конфликта сущностей
/// </summary>
/// <typeparam name="T">Сущность.</typeparam>
public class EntityConflictException<T> : BaseConflictException where T : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paramName">Название параметра.</param>
    public EntityConflictException(string paramName)
        : base(typeof(T).Name, paramName)
    {
    }
}