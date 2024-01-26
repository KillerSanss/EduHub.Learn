using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.ErrorMessages;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая преподавателя
/// </summary>
public class Educator : CummonFeilds
{
    /// <summary>
    /// Получение уникального Id для преподавателя
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Получение стажа работы преподавателя в годах
    /// </summary>
    public int WorkExperience { get; private set; }

    /// <summary>
    /// Получение даты начала работы преподавателя
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Список всех курсов, которые ведет преподаватель
    /// </summary>
    private List<Course> _courses = new();

    /// <summary>
    /// Коструктор для установки значений полей для проподавателя
    /// </summary>
    public Educator(Guid id, FullName fullName, Gender gender, int workExperience, DateTime startDate, FullPhone phoneNumber) : base(fullName, gender,
        phoneNumber)
    {
        Id = Guard.Against.Default(id);
        WorkExperience = Guard.Against.Negative(workExperience, string.Format(ErrorMessage.NegativeError, nameof(workExperience)));
        StartDate = Guard.Against.Null(startDate, string.Format(ErrorMessage.NullError, nameof(startDate)));
    }

    /// <summary>
    /// Метод для получения списка всех курсов учителя
    /// </summary>
    public List<Course> GetCourse()
    {
        return _courses;
    }

    /// <summary>
    /// Метод для обновления преподавателя
    /// </summary>
    public void UpdateEducator(FullName fullName, Gender gender, int workExperience, DateTime startDate, FullPhone phoneNumber)
    {
        FullName = Guard.Against.Null(fullName, string.Format(ErrorMessage.NullError, nameof(fullName))); // Я не уверен насчет проверки общих полей. Типо они в классе CummonFeilds уже валидируются.
        Gender = Guard.Against.Gender(gender);
        PhoneNumber = Guard.Against.Null(phoneNumber, string.Format(ErrorMessage.NullError, nameof(phoneNumber)));
        WorkExperience = Guard.Against.Negative(workExperience, string.Format(ErrorMessage.NegativeError, nameof(workExperience)));
        StartDate = Guard.Against.Null(startDate, string.Format(ErrorMessage.NullError, nameof(startDate)));
    }
}