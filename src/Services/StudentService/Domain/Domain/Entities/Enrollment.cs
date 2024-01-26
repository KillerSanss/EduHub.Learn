using Ardalis.GuardClauses;
using Domain.Validations.ErrorMessages;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая зачисления на курсы
/// </summary>
public class Enrollment
{
    /// <summary>
    /// Получение уникального Id для зачисления
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Получение Id студента, зачислевшегося на курс
    /// </summary>
    public Guid StudentId { get; private set; }

    /// <summary>
    /// Получение Id курса, на который идет зачисление
    /// </summary>
    public Guid CourseId { get; private set; }

    /// <summary>
    /// Получение даты зачисления
    /// </summary>
    public DateTime StartCourseDate { get; private set; } ////

    /// <summary>
    /// Коструктор для установки значений полей для зачисления
    /// </summary>
    public Enrollment(Guid id, Guid studentId, Guid courseId, DateTime startCourseDate)
    {
        Id = Guard.Against.Default(id);
        StudentId = Guard.Against.Default(studentId);
        CourseId = Guard.Against.Default(courseId);
        StartCourseDate = Guard.Against.Null(startCourseDate, string.Format(ErrorMessage.NullError, nameof(startCourseDate)));
    }
}