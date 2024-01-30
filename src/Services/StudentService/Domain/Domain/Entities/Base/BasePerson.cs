using Domain.Entities.ValueObjects;
using Domain.Entities.Enums;
using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities.Base;

/// <summary>
/// Класс общих полей сущностей
/// </summary>
public abstract class BasePerson : BaseEntity
{
    /// <summary>
    /// Имя
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
    /// Метод установки значения для FullName
    /// </summary>
    protected void SetFullName(Name fullName)
    {
        FullName = Guard.Against.Null(fullName);
    }

    /// <summary>
    /// Метод установки значения для Gender
    /// </summary>
    protected void SetGender(Gender gender)
    {
        Gender = Guard.Against.Enum(gender);
    }

    /// <summary>
    /// Метод установки значения для Phone
    /// </summary>
    protected void SetPhone(Phone phone)
    {
        Phone = Guard.Against.Null(phone);
    }
}