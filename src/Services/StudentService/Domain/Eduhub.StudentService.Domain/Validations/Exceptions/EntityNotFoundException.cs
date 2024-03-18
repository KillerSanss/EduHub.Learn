using Eduhub.StudentService.Domain.Validations.Exceptions.Base;

namespace Eduhub.StudentService.Domain.Validations.Exceptions;

/// <summary>
/// Исключение для не найденых объектов
/// </summary>
public class EntityNotFoundException<T> : BaseNotFoundException
{
    public EntityNotFoundException(string paramName, string value)
        : base(nameof(T), paramName, value)
    {
    }
}