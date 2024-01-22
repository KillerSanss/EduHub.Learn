using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

public class Educator
{
    public FullName Name;
    public Genders Gender;
    public int WorkExp;
    public DateTime WorkStartDate;
    public string PhoneNumber;

    public List<Course> Courses;

    public Educator(FullName name, Genders gender, int workExp, DateTime workStartDate, string phoneNumber)
    {
        Name = name;
        Gender = Guard.Against.GenderValidation(gender);
        WorkExp = Guard.Against.Negative(workExp);
        WorkStartDate = Guard.Against.Null(workStartDate);
        PhoneNumber = Guard.Against.PhoneValidation(phoneNumber);
    }
}