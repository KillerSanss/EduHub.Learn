using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations.Enums;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения полного адреса
/// </summary>
public class FullAddress
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
    public FullAddress(string city, string street, int houseNumber)
    {
        City = Guard.Against.String(city, 60, Operation.LessThanOrEqual);
        Street = Guard.Against.String(street, 60, Operation.LessThanOrEqual);
        HouseNumber = Guard.Against.Negative(houseNumber);
    }
}