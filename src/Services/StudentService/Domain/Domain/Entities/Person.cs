using Ardalis.GuardClauses;
using Domain.Entities.ValueObjects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Класс общих полей сущностей, для избежания повторения кода
/// </summary>
public abstract class Person
{
    /// <summary>
    /// Ай-ди
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Имя
    /// </summary>
    public Name Name { get; protected set; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; protected set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public Phone PhoneNumber { get; protected set; }

    /// <summary>
    /// Коструктор для установки значений полей общих полей
    /// </summary>
    protected Person(Guid id, Name name, Gender gender, Phone phoneNumber)
    {
        Id = Guard.Against.Default(id);
        Name = Guard.Against.Null(name);
        Gender = Guard.Against.Enum(gender);
        PhoneNumber = Guard.Against.Null(phoneNumber);
    }

    /// <summary>
    /// Перегрузка конструктора
    /// </summary>
    protected Person(Guid id)
    {
        Id = Guard.Against.Default(id);
    }
}