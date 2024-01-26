using Domain.Validations.Exceptions.Core;

namespace Domain.Validations.Exceptions;

/// <summary>
/// Класс для описания кастомного исключения EntityNullException для ошибок удаления из списка
/// </summary>
public class EntityNullException : BaseEntityException
{
    public EntityNullException(string message) : base(message)
    {
    }
}