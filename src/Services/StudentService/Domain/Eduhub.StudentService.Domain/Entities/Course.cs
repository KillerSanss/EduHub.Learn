﻿using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Base;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations;

namespace Eduhub.StudentService.Domain.Entities;

/// <summary>
/// Сущность, описывающая курс
/// </summary>
public class Course : BaseEntity
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; private set; }

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
        Name = Guard.Against.Regex(courseName, RegexPatterns.LettersPattern);
    }

    /// <summary>
    /// Установка описания
    /// </summary>
    private void SetDescription(string description)
    {
        Description = Guard.Against.String(description, 100, Operation.GreaterThan);
    }

    /// <summary>
    /// Установка идентификатора учителя
    /// </summary>
    private void SetEducatorId(Guid educatorId)
    {
        EducatorId = Guard.Against.Default(educatorId);
    }
}