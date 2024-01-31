using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations.RegularExpressions;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения полного адреса
/// </summary>
public class Address
{
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }

    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }

    /// <summary>
    /// Номер дома
    /// </summary>
    public int HouseNumber { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Address.
    /// </summary>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="houseNumber">Номер дома.</param>
    public Address(string city, string street, int houseNumber)
    {
        City = Guard.Against.Regex(city, RegexPatterns.LettersPattern);
        Street = Guard.Against.Regex(street, RegexPatterns.LettersPattern);
        HouseNumber = Guard.Against.Negative(houseNumber);
    }
}