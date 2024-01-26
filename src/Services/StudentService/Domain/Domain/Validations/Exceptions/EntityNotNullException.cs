using Domain.Validations.Exceptions.Core;

namespace Domain.Validations.Exceptions;

/// <summary>
/// Класс для описания кастомного исключения EntityNotNullException для ошибок добавления в список
/// </summary>
public class EntityNotNullException : BaseEntityException
{
    public EntityNotNullException(string message) : base(message)
    {
    }
}