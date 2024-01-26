using Domain.Validations.Exceptions.Core;

namespace Domain.Validations.Exceptions;

/// <summary>
/// Класс для описания кастомного исключения EntityValidationException для ошибок ввода данных для сущностей
/// </summary>
public class EntityValidationException : BaseEntityException
{
    public EntityValidationException(string message) : base(message)
    {
    }
}