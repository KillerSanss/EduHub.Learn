using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.ErrorMessages;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

/// <summary>
/// Класс общих полей сущностей, для избежания повторения кода
/// </summary>
public class CummonFeilds
{
    public FullName FullName { get; set; }
    public Gender Gender { get; set; }
    public FullPhone PhoneNumber { get; set; }

    public CummonFeilds(FullName fullName, Gender gender, FullPhone phoneNumber)
    {
        FullName = Guard.Against.Null(fullName, string.Format(ErrorMessage.NullError, nameof(fullName)));
        Gender = Guard.Against.Gender(gender);
        PhoneNumber = Guard.Against.Null(phoneNumber, string.Format(ErrorMessage.NullError, nameof(phoneNumber)));
    }
}