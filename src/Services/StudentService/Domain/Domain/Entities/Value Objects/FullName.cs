using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities.Value_Objects;

public class FullName
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }

    public FullName(string firstName, string secondName, string lastName)
    {
        Guard.Against.StringValidation(firstName);
        Guard.Against.StringValidation(secondName);
        Guard.Against.StringValidation(lastName);

        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
    }
}