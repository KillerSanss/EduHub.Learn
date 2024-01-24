using Ardalis.GuardClauses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая зачисления на курсы
/// </summary>
public class Enrollment
{
    /// <summary>
    /// Получение уникального Id для зачисления
    /// </summary>
    public Guid EnrollmentId { get; private set; }
    
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
    public DateTime EnrollmentDate { get; private set; }

    /// <summary>
    /// Коструктор для установки значений полей для зачисления
    /// </summary>
    public Enrollment(Guid studentId, Guid courseId, DateTime enrollmentDate)
    {
        EnrollmentId = Guid.NewGuid();
        StudentId = Guard.Against.Default(studentId);
        CourseId = Guard.Against.Default(courseId);
        EnrollmentDate = Guard.Against.Null(enrollmentDate);
    }
}