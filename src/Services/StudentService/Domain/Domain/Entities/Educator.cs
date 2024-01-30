using Ardalis.GuardClauses;
using Domain.Entities.ValueObjects;
using Domain.Entities.Enums;
using Domain.Entities.Base;

namespace Domain.Entities;

/// <summary>
/// Сущность, описывающая преподавателя
/// </summary>
public class Educator : BasePerson
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
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="workExperience">Опыт работы.</param>
    /// <param name="startDate">Начало работы.</param>
    /// <param name="phone">.</param>
    public Educator(
        Guid id
        , Name fullName
        , Gender gender
        , int workExperience
        , DateTime startDate
        , Phone phone)
    {
        Common(id, fullName, gender, workExperience, startDate, phone);
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
    public void Update(Guid id, Name fullName, Gender gender, int workExperience, DateTime startDate, Phone phone)
    {
        Common(id, fullName, gender, workExperience, startDate, phone);
    }

    /// <summary>
    /// Метод для установки значений Educator
    /// </summary>
    private void Common(Guid id, Name fullName, Gender gender, int workExperience, DateTime startDate, Phone phone)
    {
        SetId(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhone(phone);
        WorkExperience = Guard.Against.Negative(workExperience);
        StartDate = Guard.Against.Null(startDate);
    }
}