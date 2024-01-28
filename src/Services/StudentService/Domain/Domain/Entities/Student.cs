using Ardalis.GuardClauses;
using Domain.Entities.ValueObjects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;
using Domain.Validations.ErrorMessages;
using Domain.Validations.Exceptions.StudentExceptions;

namespace Domain.Entities;

/// <summary>
/// Сущность описывающая студента
/// </summary>
public class Student : Person
{
    /// <summary>
    /// Список зачислений
    /// </summary>
    private readonly List<Enrollment> _enrollments = new();

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    /// Аватар
    /// </summary>
    public string Avatar { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Student.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="name">Имя.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="email">Электронная почта.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="avatar">Аватар.</param>
    public Student(
        Guid id
        , Name name
        , Gender gender
        , DateTime birthDate
        , Email email
        , Phone phoneNumber
        , Address address
        , string avatar) : base(id, name, gender, phoneNumber)
    {
        Common(id, name, gender, birthDate, email, phoneNumber, address, avatar);
    }

    /// <summary>
    /// Метод для получения списка всех зачислений студента
    /// </summary>
    public IEnumerable<Enrollment> GetEnrollments()
    {
        return _enrollments;
    }

    /// <summary>
    /// Метод для добавления нового зачисления в список
    /// </summary>
    public void Add(Guid enrollmentId, Guid courseId, DateTime startCourseDate)
    {
        var enrollment = _enrollments.FirstOrDefault(e => e.Id == enrollmentId);
        if (enrollment != null)
        {
            throw new StudentNotNullException(string.Format(ErrorMessage.NotNullError, nameof(enrollmentId)));
        }

        var newEnrollment = new Enrollment(enrollmentId, Id, courseId, startCourseDate);
        _enrollments.Add(newEnrollment);
    }

    /// <summary>
    /// Метод для обновления значений полей сущности Student
    /// </summary>
    public void Update(
        Guid id
        , Name name
        , Gender gender
        , DateTime birthDate
        , Email email
        , Phone phoneNumber
        , Address address,
        string avatar)
    {
        Common(id, name, gender, birthDate, email, phoneNumber, address, avatar);
    }

    /// <summary>
    /// Метод для удаления зачисления
    /// </summary>
    public void Delete(Guid enrollmentId)
    {
        var enrollment = _enrollments.FirstOrDefault(e => e.Id == enrollmentId);
        if (enrollment == null)
        {
            throw new StudentNotFoundException(string.Format(ErrorMessage.NullError, nameof(enrollmentId)));
        }

        _enrollments.Remove(enrollment);
    }

    /// <summary>
    /// Метод для избежания повторений в коде при валидации полей Student
    /// </summary>
    private void Common(Guid id, Name name, Gender gender, DateTime birthDate, Email email, Phone phoneNumber, Address address, string avatar)
    {
        Id = Guard.Against.Default(id);
        Name = Guard.Against.Null(name);
        Gender = Guard.Against.Enum(gender);
        BirthDate = Guard.Against.Date(birthDate);
        Email = Guard.Against.Null(email);
        PhoneNumber = Guard.Against.Null(phoneNumber);
        Address = Guard.Against.Null(address);
        Avatar = Guard.Against.Regex(avatar, RegexPatterns.AvatarUrlPattern);
    }
}