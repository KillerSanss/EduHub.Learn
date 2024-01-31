using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Base;

namespace Eduhub.StudentService.Domain.Entities;

/// <summary>
/// Сущность, описывающая зачисления на курсы
/// </summary>
public class Enrollment : BaseEntity
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
    public Enrollment(Guid id, Guid studentId, Guid courseId, DateTime startDate)
    {
        SetId(id);
        SetStudentId(studentId);
        SetCourseId(courseId);
        SetStartDate(startDate);
    }

    /// <summary>
    /// Установка индентификатора студента
    /// </summary>
    private void SetStudentId(Guid studentId)
    {
        StudentId = Guard.Against.Default(studentId);
    }

    /// <summary>
    /// Установка идентификатора курса
    /// </summary>
    private void SetCourseId(Guid courseId)
    {
        CourseId = Guard.Against.Default(courseId);
    }

    /// <summary>
    /// Установка даты зачисления
    /// </summary>
    private void SetStartDate(DateTime startDate)
    {
        StartDate = Guard.Against.Null(startDate);
    }
}