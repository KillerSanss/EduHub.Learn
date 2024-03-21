namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для конфликтов
/// </summary>
public abstract class BaseConflictException : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entityName">Название сущности.</param>
    /// <param name="paramName">Название параметра.</param>
    /// <param name="value">Значение параметра.</param>
    protected BaseConflictException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.ConflictError, entityName, paramName, value))
    {
    }
}