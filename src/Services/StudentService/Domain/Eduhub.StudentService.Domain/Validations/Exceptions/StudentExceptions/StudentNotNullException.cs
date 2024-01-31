using Eduhub.StudentService.Domain.Validations.Exceptions.Core;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.StudentExceptions;

/// <summary>
/// Класс для описания кастомного исключения StudentNotNullException для ошибок сущности Student
/// </summary>
public class StudentNotNullException : BaseEntityException
{
    public StudentNotNullException(string message) : base(message)
    {
    }
}