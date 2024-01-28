using Domain.Validations.Exceptions.Core;

namespace Domain.Validations.Exceptions.StudentExceptions
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