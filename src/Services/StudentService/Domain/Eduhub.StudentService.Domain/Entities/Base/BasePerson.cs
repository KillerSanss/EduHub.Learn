using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.GuardClasses;

namespace Eduhub.StudentService.Domain.Entities.Base;

/// <summary>
/// Класс общих полей сущностей
/// </summary>
public abstract class BasePerson : BaseEntity
{
    /// <summary>
    /// Фио
    /// </summary>
    public FullName FullName { get; set; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public Phone Phone { get; set; }

    /// <summary>
    /// Установка фио
    /// </summary>
    protected void SetFullName(FullName fullName)
    {
        FullName = Guard.Against.Null(fullName);
    }

    /// <summary>
    /// Установка гендера
    /// </summary>
    protected void SetGender(Gender gender)
    {
        Gender = Guard.Against.Enum(gender, defaultValues: Gender.None);
    }

    /// <summary>
    /// Установка номера телефона
    /// </summary>
    protected void SetPhone(Phone phone)
    {
        Phone = Guard.Against.Null(phone);
    }
}