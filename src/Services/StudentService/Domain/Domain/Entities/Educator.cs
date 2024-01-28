using Ardalis.GuardClauses;
using Domain.Entities.ValueObjects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая преподавателя
/// </summary>
public class Educator : Person
{
    /// <summary>
    /// Список курсов
    /// </summary>
    private readonly List<Course> _courses = new();

    /// <summary>
    /// Опыт работы
    /// </summary>
    public int WorkExperience { get; private set; }

    /// <summary>
    /// Начало работы
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Educator.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="name">Имя.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="workExperience">Опыт работы.</param>
    /// <param name="startDate">Начало работы.</param>
    /// <param name="phoneNumber">.</param>
    public Educator(
        Guid id
        , Name name
        , Gender gender
        , int workExperience
        , DateTime startDate
        , Phone phoneNumber) : base(id, name, gender, phoneNumber)
    {
        Common(id, name, gender, workExperience, startDate, phoneNumber);
    }

    /// <summary>
    /// Метод для получения списка всех курсов учителя
    /// </summary>
    public IEnumerable<Course> GetCourse()
    {
        return _courses;
    }

    /// <summary>
    /// Метод для обновления полей сущности Educator
    /// </summary>
    public void Update(Guid id, Name name, Gender gender, int workExperience, DateTime startDate, Phone phoneNumber)
    {
        Common(id, name, gender, workExperience, startDate, phoneNumber);
    }

    /// <summary>
    /// Метод для избежания повторений в коде при валидации полей Educator
    /// </summary>
    private void Common(Guid id, Name name, Gender gender, int workExperience, DateTime startDate, Phone phoneNumber)
    {
        Id = Guard.Against.Default(id);
        Name = Guard.Against.Null(name);
        Gender = Guard.Against.Enum(gender);
        PhoneNumber = Guard.Against.Null(phoneNumber);
        WorkExperience = Guard.Against.Negative(workExperience);
        StartDate = Guard.Against.Null(startDate);
    }
}