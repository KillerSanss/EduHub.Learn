using Eduhub.StudentService.Domain.Validations.ErrorMessages;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для конфликтов
/// </summary>
/// <param name="entityName">Название сущности.</param>
/// <param name="paramName">Название параметра.</param>
/// <param name="value">Id сущности.</param>
public class BaseConflictException : Exception
{
    protected BaseConflictException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.ConflictError, entityName, paramName, value))
    {
    }
   
}