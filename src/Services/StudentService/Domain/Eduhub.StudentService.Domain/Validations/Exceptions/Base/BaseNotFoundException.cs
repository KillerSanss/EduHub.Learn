namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для не найденых объектов
/// </summary>
public abstract class BaseNotFoundException : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entityName">Имя сущнсти.</param>
    /// <param name="paramName">Название параметра.</param>
    /// <param name="value">Значение параметра</param>
    protected BaseNotFoundException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.NotFoundError, entityName, paramName, value))
    {
    }
}