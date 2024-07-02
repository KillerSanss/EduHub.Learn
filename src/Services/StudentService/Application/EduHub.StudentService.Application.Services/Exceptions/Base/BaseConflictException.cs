using ErrorMessages = EduHub.StudentService.Application.Services.Primitives.ErrorMessages;

namespace EduHub.StudentService.Application.Services.Exceptions.Base;

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
    protected BaseConflictException(string entityName, string paramName)
        : base(string.Format(ErrorMessages.ConflictError, entityName, paramName))
    {
    }
}