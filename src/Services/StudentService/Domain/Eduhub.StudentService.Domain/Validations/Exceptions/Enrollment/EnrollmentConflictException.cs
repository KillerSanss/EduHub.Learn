using Eduhub.StudentService.Domain.Validations.Exceptions.Core;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment
{
    /// <summary>
    /// Класс для описания кастомного исключения EnrollmentNotFoundException для ошибок сущности Student
    /// </summary>
    public class EnrollmentConflictException : BaseEntityException
    {
        public EnrollmentConflictException(string message) : base(message)
        {
        }
    }
}