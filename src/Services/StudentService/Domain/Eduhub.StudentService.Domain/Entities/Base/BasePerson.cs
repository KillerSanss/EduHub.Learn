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
    public Name FullName { get; protected set; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; protected set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public Phone Phone { get; protected set; }

    /// <summary>
    /// Установка фио
    /// </summary>
    protected void SetFullName(Name fullName)
    {
        FullName = Guard.Against.Null(fullName);
    }

    /// <summary>
    /// Установка гендера
    /// </summary>
    protected void SetGender(Gender gender)
    {
        Gender = Guard.Against.Enum(gender);
    }

    /// <summary>
    /// Установка номера телефона
    /// </summary>
    protected void SetPhone(Phone phone)
    {
        Phone = Guard.Against.Null(phone);
    }
}