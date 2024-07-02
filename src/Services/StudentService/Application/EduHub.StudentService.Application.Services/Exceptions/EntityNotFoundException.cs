using EduHub.StudentService.Application.Services.Exceptions.Base;
using Eduhub.StudentService.Domain.Entities.Base;

namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение для ненайденных объектов
/// </summary>
/// <typeparam name="T">Сущность.</typeparam>
public class EntityNotFoundException<T> : BaseNotFoundException where T : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paramName">Название параметра.</param>
    /// <param name="value">Значение параметра.</param>
    public EntityNotFoundException(string paramName, string value)
        : base(typeof(T).Name, paramName, value)
    {
    }
}