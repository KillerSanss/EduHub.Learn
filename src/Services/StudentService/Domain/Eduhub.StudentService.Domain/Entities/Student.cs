using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Base;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.ErrorMessages;
using Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations;

namespace Eduhub.StudentService.Domain.Entities;

/// <summary>
/// Сущность описывающая студента
/// </summary>
public class Student : BasePerson
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
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="email">Электронная почта.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="avatar">Аватар.</param>
    public Student(
        Guid id
        , FullName fullName
        , Gender gender
        , DateTime birthDate
        , Email email
        , Phone phone
        , Address address
        , string avatar)
    {
        SetId(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhone(phone);
        SetBirthDate(birthDate);
        SetEmail(email);
        SetAddress(address);
        SetAvatar(avatar);
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
            throw new EnrollmentConflictException(string.Format(ErrorMessage.ConflictError, nameof(enrollmentId)));
        }

        var newEnrollment = new Enrollment(enrollmentId, Id, courseId, startCourseDate);
        _enrollments.Add(newEnrollment);
    }

    /// <summary>
    /// Метод для обновления значений полей сущности Student
    /// </summary>
    public void Update(
        FullName fullName
        , Gender gender
        , DateTime birthDate
        , Email email
        , Phone phone
        , Address address,
        string avatar)
    {
        SetFullName(fullName);
        SetGender(gender);
        SetPhone(phone);
        SetBirthDate(birthDate);
        SetEmail(email);
        SetAddress(address);
        SetAvatar(avatar);
    }

    /// <summary>
    /// Метод для удаления зачисления
    /// </summary>
    public void Delete(Guid enrollmentId)
    {
        var enrollment = _enrollments.FirstOrDefault(e => e.Id == enrollmentId);
        if (enrollment == null)
        {
            throw new EnrollmentNotFoundException(string.Format(ErrorMessage.NotFoundError, nameof(enrollmentId)));
        }

        _enrollments.Remove(enrollment);
    }

    /// <summary>
    /// Установка дня рождения
    /// </summary>
    private void SetBirthDate(DateTime birthDate)
    {
        BirthDate = Guard.Against.FutureDate(birthDate);
    }

    /// <summary>
    /// Установка электроной почты
    /// </summary>
    private void SetEmail(Email email)
    {
        Email = Guard.Against.Null(email);
    }

    /// <summary>
    /// Установка адреса
    /// </summary>
    private void SetAddress(Address address)
    {
        Address = Guard.Against.Null(address);
    }

    /// <summary>
    /// Установка аватара
    /// </summary>
    private void SetAvatar(string avatar)
    {
        Avatar = Guard.Against.Regex(avatar, RegexPatterns.AvatarUrlPattern);
    }
}