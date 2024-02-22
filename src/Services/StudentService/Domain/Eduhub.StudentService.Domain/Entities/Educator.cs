using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Base;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.GuardClasses;

namespace Eduhub.StudentService.Domain.Entities;

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
    /// <param name="phone">Номер телефона.</param>
    public Educator(
        Guid id,
        FullName fullName,
        Gender gender,
        int workExperience,
        DateTime startDate,
        Phone phone)
    {
        SetId(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhone(phone);
        SetWorkExperience(workExperience);
        SetStartDate(startDate);
    }

    public Educator()
    {
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
    public void Update(FullName fullName, Gender gender, int workExperience, DateTime startDate, Phone phone)
    {
        SetFullName(fullName);
        SetGender(gender);
        SetPhone(phone);
        SetWorkExperience(workExperience);
        SetStartDate(startDate);
    }

    /// <summary>
    /// Установка опыта работы
    /// </summary>
    private void SetWorkExperience(int workExperience)
    {
        WorkExperience = Guard.Against.Negative(workExperience);
    }

    /// <summary>
    /// Установка даты начала работы
    /// </summary>
    private void SetStartDate(DateTime startDate)
    {
        StartDate = Guard.Against.FutureDate(startDate);
    }
}