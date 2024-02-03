using Eduhub.StudentService.Domain.Validations.ErrorMessages;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для не найденых объектов
/// </summary>
/// <param name="entityName">Название сущности.</param>
/// <param name="paramName">Название параметра.</param>
/// <param name="value">Id сущности.</param>
public class BaseNotFoundException : Exception
{
    protected BaseNotFoundException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.NotFoundError, entityName, paramName, value))
    {
    }
}