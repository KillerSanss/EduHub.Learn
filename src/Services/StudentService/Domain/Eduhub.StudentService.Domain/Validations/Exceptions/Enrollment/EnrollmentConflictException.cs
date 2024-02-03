using Eduhub.StudentService.Domain.Validations.Exceptions.Base;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment
{
    /// <summary>
    /// Исключение при возникновении конфликта
    /// </summary>
    /// <param name="paramName">Название параметра.</param>
    /// <param name="value">Значение параметра.</param>
    public class EnrollmentConflictException : BaseConflictException
    {
        public EnrollmentConflictException(string paramName, string value)
            : base(nameof(Enrollment), paramName, value)
        {
        }
    }
}