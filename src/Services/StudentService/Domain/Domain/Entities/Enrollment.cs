using Ardalis.GuardClauses;

namespace Domain.Entities;

public class Enrollment
{
    public int StudentId;
    public int CourseId;
    public DateTime EnrollmentDate;

    public Enrollment(int studentId, int courseId, DateTime enrollmentDate)
    {
        StudentId = Guard.Against.Null(studentId);
        CourseId = Guard.Against.Null(courseId);
        EnrollmentDate = Guard.Against.Null(enrollmentDate);
    }
}