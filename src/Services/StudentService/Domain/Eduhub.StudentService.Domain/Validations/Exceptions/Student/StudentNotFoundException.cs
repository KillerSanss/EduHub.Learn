using Eduhub.StudentService.Domain.Validations.Exceptions.Core;

namespace Eduhub.StudentService.Domain.Validations.Exceptions.Student
{
    /// <summary>
    /// Класс для описания кастомного исключения StudentNotFoundException для ошибок сущности Student
    /// </summary>
    public class StudentNotFoundException : BaseEntityException
    {
        public StudentNotFoundException(string message) : base(message)
        {
        }
    }
}