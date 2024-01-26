using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;
using Domain.Validations.ErrorMessages;

namespace Domain.Entities.Value_Objects;

/// <summary>
/// Value Object для получения полного адреса
/// </summary>
public class FullAddress
{
    /// <summary>
    /// Поле описывающее название город
    /// </summary>
    public string City { get; private set; }

    /// <summary>
    /// Поле описывающее название улицы
    /// </summary>
    public string Street { get; private set; }

    /// <summary>
    /// Поле описывающее номер дома
    /// </summary>
    public int HouseNumber { get; private set; }

    /// <summary>
    /// Конструктор для устновки значений полей для FullName
    /// </summary>
    public FullAddress(string city, string street, int houseNumber)
    {
        City = Guard.Against.Regex(city, RegexPatterns.LettersPattern);
        Street = Guard.Against.Regex(street, RegexPatterns.LettersPattern);
        HouseNumber = Guard.Against.Negative(houseNumber,string.Format(ErrorMessage.NegativeError, nameof(houseNumber)));
    }
}