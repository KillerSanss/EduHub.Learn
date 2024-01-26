using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая курс
/// </summary>
public class Course
{
    /// <summary>
    /// Получение уникального Id курса
    /// </summary>
    public Guid Id { get; private set; }

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
    public Course(Guid id, string courseName, string description, Guid educatorId)
    {
        Id = Guard.Against.Default(id);
        CourseName = Guard.Against.Regex(courseName, RegexPatterns.LettersPattern);
        Description = Guard.Against.String(description);
        EducatorId = Guard.Against.Default(educatorId);
    }

    /// <summary>
    /// Метод для обновления курса
    /// </summary>
    public void UpdateCourse(string courseName, string description, Guid educatorId)
    {
        CourseName = Guard.Against.Regex(courseName, RegexPatterns.LettersPattern);
        Description = Guard.Against.String(description);
        EducatorId = Guard.Against.Default(educatorId);
    }
}