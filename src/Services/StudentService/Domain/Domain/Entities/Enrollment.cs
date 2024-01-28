using Ardalis.GuardClauses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая зачисления на курсы
/// </summary>
public class Enrollment : Person
{
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid StudentId { get; private set; }

    /// <summary>
    /// Id курса
    /// </summary>
    public Guid CourseId { get; private set; }

    /// <summary>
    /// Дата зачисления
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Enrollment.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="studentId">Id студента.</param>
    /// <param name="courseId">Id курса.</param>
    /// <param name="startDate">Дата зачисления.</param>
    public Enrollment(Guid id, Guid studentId, Guid courseId, DateTime startDate): base(id)
    {
        StudentId = Guard.Against.Default(studentId);
        CourseId = Guard.Against.Default(courseId);
        StartDate = Guard.Against.Null(startDate);
    }
}