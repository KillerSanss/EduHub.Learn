using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая курс
/// </summary>
public class Course
{
    /// <summary>
    /// Получение уникального Id курса
    /// </summary>
    public Guid CourseId { get; private set; }

    /// <summary>
    /// Получение названия курса
    /// </summary>
    public string CourseName { get; private set; }

    /// <summary>
    /// Получение описания курса
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Получение Id проподавателя, который этот курс преподает
    /// </summary>
    public Guid EducatorId { get; private set; }

    /// <summary>
    /// Коструктор для установки значений полей для курса
    /// </summary>
    public Course(string courseName, string description, Guid educatorId)
    {
        CourseId = Guid.NewGuid();
        CourseName = Guard.Against.NameValueValidation(courseName);
        Description = Guard.Against.DescriptionValidation(description);
        EducatorId = Guard.Against.Default(educatorId);
    }
}