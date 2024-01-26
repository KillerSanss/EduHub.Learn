using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;
using Domain.Validations.ErrorMessages;
using Domain.Validations.Exceptions;

namespace Domain.Entities;

/// <summary>
/// Сущность описывающая студента
/// </summary>
public class Student : CummonFeilds
{
    /// <summary>
    /// Получение уникального Id для студента
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Получение даты рождения студента
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Получение электронной почты студента
    /// </summary>
    public FullEmail Email { get; private set; }

    /// <summary>
    /// Получение полного адреса студента через value object FullAddress
    /// </summary>
    public FullAddress FullAddress { get; private set; }

    /// <summary>
    /// Получение ссылки на аватар студента
    /// </summary>
    public string Avatar { get; private set; }

    /// <summary>
    /// Получение списка всех зачислений студента
    /// </summary>
    private List<Enrollment> _enrollments = new();

    /// <summary>
    /// Коструктор для установки значений полей для студента
    /// </summary>
    public Student(Guid id, FullName fullName, Gender gender, DateTime birthDate, FullEmail email, FullPhone phoneNumber, FullAddress fullAddress, string avatar)
                : base(fullName, gender, phoneNumber)
    {
        Id = Guard.Against.Default(id);
        BirthDate = Guard.Against.BirthValidation(birthDate);
        Email = Guard.Against.Null(email, string.Format(ErrorMessage.NullError, nameof(email)));
        FullAddress = Guard.Against.Null(fullAddress, string.Format(ErrorMessage.NullError, nameof(fullAddress)));
        Avatar = Guard.Against.Regex(avatar, RegexPatterns.AvatarUrlPattern);
    }

    /// <summary>
    /// Метод для получения списка всех зачислений студента
    /// </summary>
    public List<Enrollment> GetEnrollments()
    {
        return _enrollments;
    }

    /// <summary>
    /// Метод для добавления нового зачисления в список
    /// </summary>
    public void AddEnrollment(Guid enrollmentId, Guid courseId, DateTime startCourseDate)
    {
        var exist = _enrollments.FirstOrDefault(e => e.Id == enrollmentId);
        if (exist != null)
        {
            throw new EntityNotNullException(string.Format(ErrorMessage.NotNullError, nameof(enrollmentId)));
        }

        var enrollment = new Enrollment(enrollmentId, Id, courseId, startCourseDate);
        _enrollments.Add(enrollment);
    }

    /// <summary>
    /// Метод для обновления информации о студенте
    /// </summary>
    public void UpdateStudent(FullName fullName, Gender gender, DateTime birthDate, FullEmail email, FullPhone phoneNumber, FullAddress fullAddress,
        string avatar)
    {
        FullName = Guard.Against.Null(fullName, string.Format(ErrorMessage.NullError, nameof(fullName))); // Я не уверен насчет проверки общих полей. Типо они в классе CummonFeilds уже валидируются.
        Gender = Guard.Against.Gender(gender);
        BirthDate = Guard.Against.BirthValidation(birthDate);
        Email = Guard.Against.Null(email, string.Format(ErrorMessage.NullError, nameof(email)));
        PhoneNumber = Guard.Against.Null(phoneNumber, string.Format(ErrorMessage.NullError, nameof(phoneNumber)));
        FullAddress = Guard.Against.Null(fullAddress, string.Format(ErrorMessage.NullError, nameof(fullAddress)));
        Avatar = Guard.Against.Regex(avatar, RegexPatterns.AvatarUrlPattern);
    }

    /// <summary>
    /// Метод для удаления студента
    /// </summary>
    public void DeleteEnrollement(Guid enrollmentId)
    {
        var exist = _enrollments.FirstOrDefault(e => e.Id == enrollmentId);
        if (exist == null)
        {
            throw new EntityNullException(string.Format(ErrorMessage.NullError, nameof(enrollmentId)));
        }

        _enrollments.RemoveAll(e => e.Id == enrollmentId);
    }
}