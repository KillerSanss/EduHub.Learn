using Ardalis.GuardClauses;
using Domain.Entities.Value_Objects;
using Domain.Entities.Enums;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

public class Student
{
    public FullName Name;
    public Genders Gender;
    public DateTime BirthDate;
    public string Email;
    public string PhoneNumber;
    public FullAdress Adress;
    public string Avatar;
    public List<Enrollment> Enrollments;

    public Student(FullName name, Genders gender, DateTime birthDate, string email, string phoneNumber, FullAdress adress, string avatar)
    {
        Name = name;
        Gender = Guard.Against.GenderValidation(gender);
        BirthDate = Guard.Against.BirthValidation(birthDate);
        Email = Guard.Against.EmailValidation(email);
        PhoneNumber = Guard.Against.PhoneValidation(phoneNumber);
        Adress = adress;
        Avatar = Guard.Against.AvatarUrlValidation(avatar);
    }
}
