using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Сущность описывающая студента
/// </summary>
public class Student
{
    /// <summary>
    /// Получение уникального Id для студента
    /// </summary>
    public Guid StudentId { get; private set; }

    /// <summary>
    /// Получение полного имени студента через value object FullName
    /// </summary>
    public FullName Name { get; private set; }

    /// <summary>
    /// Получение пола студента
    /// </summary>
    public Gender Gender { get; private set; }

    /// <summary>
    /// Получение даты рождения студента
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Получение электронной почты студента
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Получение номера телефона студента
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Получение полного адреса студента через value object FullAdress
    /// </summary>
    public FullAdress Adress { get; private set; }

    /// <summary>
    /// Получение ссылки на аватар студента
    /// </summary>
    public string Avatar { get; private set; }

    /// <summary>
    /// Получение списка всех зачислений студента
    /// </summary>
    private List<Enrollment> Enrollments;

    /// <summary>
    /// Коструктор для установки значений полей для студента
    /// </summary>
    public Student(FullName name, Gender gender, DateTime birthDate, string email, string phoneNumber, FullAdress adress, string avatar)
    {
        StudentId = Guid.NewGuid();
        Name = Guard.Against.Null(name);
        Gender = Guard.Against.GenderValidation(gender);
        BirthDate = Guard.Against.BirthValidation(birthDate);
        Email = Guard.Against.EmailValidation(email);
        PhoneNumber = Guard.Against.PhoneValidation(phoneNumber);
        Adress = Guard.Against.Null(adress);
        Avatar = Guard.Against.AvatarUrlValidation(avatar);
    }
}