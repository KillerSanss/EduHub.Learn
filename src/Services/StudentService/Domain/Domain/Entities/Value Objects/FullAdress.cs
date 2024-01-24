using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities.Value_Objects;

/// <summary>
/// Value Object для получения полного адреса
/// </summary>
public class FullAdress
{
    /// <summary>
    /// Поле описывающее название город
    /// </summary>
    public readonly string City;

    /// <summary>
    /// Поле описывающее название улицы
    /// </summary>
    public readonly string Street;

    /// <summary>
    /// Поле описывающее номер дома
    /// </summary>
    public readonly int HouseNumber;

    /// <summary>
    /// Конструктор для устновки значенйи полей для FullName
    /// </summary>
    public FullAdress(string city, string street, int houseNumber)
    {
        City = Guard.Against.AdressValidation(city);
        Street = Guard.Against.AdressValidation(street);
        HouseNumber = Convert.ToInt32(Guard.Against.AdressValidation(houseNumber.ToString()));
    }
}