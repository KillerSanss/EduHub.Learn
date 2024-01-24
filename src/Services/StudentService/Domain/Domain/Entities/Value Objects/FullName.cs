using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities.Value_Objects;

public class FullName
{
    public readonly string FirstName;

    public readonly string SecondName;

    public readonly string LastName;

    public FullName(string firstName, string secondName, string lastName)
    {
        FirstName = Guard.Against.NameValueValidation(firstName);
        SecondName = Guard.Against.SecondNameValueValidation(secondName);
        LastName = Guard.Against.LastNameValueValidation(lastName);
    }
}