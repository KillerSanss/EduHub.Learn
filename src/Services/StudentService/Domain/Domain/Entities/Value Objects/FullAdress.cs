using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities.Value_Objects;

public class FullAdress
{
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }

    public FullAdress(string city, string street, int houseNumber)
    {
        Guard.Against.AdressValidation(city);
        Guard.Against.AdressValidation(street);
        Guard.Against.AdressValidation(houseNumber.ToString());

        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }
}