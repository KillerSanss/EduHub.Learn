using Eduhub.StudentService.Domain.Validations.Exceptions.Base;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment
{
    /// <summary>
    /// Исключение при не найденой сущности Enrollment
    /// </summary>
    public class EnrollmentNotFoundException : BaseNotFoundException
    {
        public EnrollmentNotFoundException(string paramName, string value)
            : base(nameof(Enrollment), paramName, value)
        {
        }
    }
}