using ErrorMessages = EduHub.StudentService.Application.Services.Primitives.ErrorMessages;

namespace EduHub.StudentService.Application.Services.Exceptions.Base;

/// <summary>
/// Базовое исключение для не найденных объектов
/// </summary>
public abstract class BaseNotFoundException : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entityName">Имя сущности.</param>
    /// <param name="paramName">Название параметра.</param>
    /// <param name="value">Значение параметра</param>
    protected BaseNotFoundException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessages.NotFoundError, entityName, paramName, value))
    {
    }
}