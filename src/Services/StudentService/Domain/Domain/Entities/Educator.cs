using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая преподавателя
/// </summary>
public class Educator
{
    /// <summary>
    /// Получение уникального Id для преподавателя
    /// </summary>
    public Guid EducatorId { get; private set; }

    /// <summary>
    /// Получение полного имени преподавателя через value object FullName
    /// </summary>
    public FullName Name { get; private set; }

    /// <summary>
    /// Получение пола преподавателя
    /// </summary>
    public Gender Gender { get; private set; }

    /// <summary>
    /// Получение стажа работы преподавателя в годах
    /// </summary>
    public int WorkExperience { get; private set; }

    /// <summary>
    /// Получение даты начала работы преподавателя
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Получение номера телефона преподавателя
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Список всех курсов, которые ведет преподаватель
    /// </summary>
    private List<Course> Courses;

    /// <summary>
    /// Коструктор для установки значений полей для проподавателя
    /// </summary>
    public Educator(FullName name, Gender gender, int workExperience, DateTime startDate, string phoneNumber)
    {
        EducatorId = Guid.NewGuid();
        Name = Guard.Against.Null(name);
        Gender = Guard.Against.GenderValidation(gender);
        WorkExperience = Guard.Against.Negative(workExperience);
        StartDate = Guard.Against.Null(startDate);
        PhoneNumber = Guard.Against.PhoneValidation(phoneNumber);
    }
}