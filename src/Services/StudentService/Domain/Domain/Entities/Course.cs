using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая курс
/// </summary>
public class Course : Person
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string CourseName { get; private set; }

    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Id преподавателя
    /// </summary>
    public Guid EducatorId { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Course.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="courseName">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="educatorId">Id преподавателя.</param>
    public Course(Guid id, string courseName, string description, Guid educatorId) : base(id)
    {
        Common(id, courseName, description, educatorId);
    }

    /// <summary>
    /// Метод для обновления курса
    /// </summary>
    public void Update(Guid id, string courseName, string description, Guid educatorId)
    {
        Common(id, courseName, description, educatorId);
    }

    /// <summary>
    /// Метод для избежания повторений в коде при валидации полей Course
    /// </summary>
    private void Common(Guid id, string courseName, string description, Guid educatorId)
    {
        Id = Guard.Against.Default(id);
        CourseName = Guard.Against.Regex(courseName, RegexPatterns.LettersPattern);
        Description = Guard.Against.String(description, 2, 100);
        EducatorId = Guard.Against.Default(educatorId);
    }
}