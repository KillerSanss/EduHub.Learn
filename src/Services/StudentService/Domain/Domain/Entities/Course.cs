using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;

namespace Domain.Entities;

public class Course
{
    public string CourseName;
    public string Description;
    public int EducatorId;

    public Course(string courseName, string description, int educatorId)
    {
        CourseName = Guard.Against.StringValidation(courseName);
        Description = description;
        EducatorId = Guard.Against.Null(educatorId);
    }
}
