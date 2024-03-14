using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Base;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations.Enums;

namespace Eduhub.StudentService.Domain.Entities;

/// <summary>
/// Сущность, описывающая курс
/// </summary>
public class Course : BaseEntity
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Id преподавателя
    /// </summary>
    public Guid EducatorId { get; set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Course.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="courseName">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="educatorId">Id преподавателя.</param>
    public Course(Guid id, string courseName, string description, Guid educatorId)
    {
        SetId(id);
        SetName(courseName);
        SetDescription(description);
        SetEducatorId(educatorId);
    }

    /// <summary>
    /// Метод для обновления курса
    /// </summary>
    public void Update(string courseName, string description, Guid educatorId)
    {
        SetName(courseName);
        SetDescription(description);
        SetEducatorId(educatorId);
    }

    /// <summary>
    /// Установка названия курса
    /// </summary>
    private void SetName(string courseName)
    {
        Name = Guard.Against.String(courseName, 50, Operation.LessThanOrEqual);
    }

    /// <summary>
    /// Установка описания
    /// </summary>
    private void SetDescription(string description)
    {
        Description = description;
    }

    /// <summary>
    /// Установка идентификатора учителя
    /// </summary>
    private void SetEducatorId(Guid educatorId)
    {
        EducatorId = Guard.Against.NullOrEmpty(educatorId);
    }
}