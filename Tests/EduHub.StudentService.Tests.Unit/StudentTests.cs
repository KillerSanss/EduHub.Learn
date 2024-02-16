using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment;

namespace Eduhub.StudentService.Tests.Unit
{
    public class StudentTests
    {
        [Fact]
        public void Student_Creation()
        {
            var id = Guid.NewGuid();
            var fullName = new FullName("Covalev", "Ivan", "Alekseevich");
            var gender = Gender.Male;
            var birthDate = new DateTime(2005, 8, 30);
            var email = new Email("vantuz0508@gmail.com");
            var phone = new Phone("+37377776987");
            var address = new FullAddress("Tiraspol", "Karl Marks", 129);
            var avatar = "https://example.com/avatar.jpeg";

            var student = new Student(id, fullName, gender, birthDate, email, phone, address, avatar);

            Assert.NotNull(student);
        }

        [Fact]
        public void Enrollment_Creation_Conflict()
        {
            var studentId = Guid.NewGuid();
            var student = new Student(studentId,
                new FullName("John", "Doe", "Smith"),
                Gender.Male, new DateTime(2000, 1, 1),
                new Email("john.doe@example.com"),
                new Phone("+37377768188"),
                new FullAddress("123 Main St", "City", 12345),
                "https://example.com/avatar.png");

            var enrollmentId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var startCourseDate = new DateTime(2021, 9, 1);

            student.AddEnrollment(enrollmentId, courseId, startCourseDate);

            Assert.Throws<EnrollmentConflictException>(() => {student.AddEnrollment(enrollmentId, courseId, startCourseDate);});
        }

        [Fact]
        public void Enrollment_Deletion_Conflict()
        {
            var studentId = Guid.NewGuid();
            var student = new Student(studentId,
                new FullName("John", "Doe", "Smith"),
                Gender.Male, new DateTime(2000, 1, 1),
                new Email("john.doe@example.com"),
                new Phone("+37377768188"),
                new FullAddress("123 Main St", "City", 12345),
                "https://example.com/avatar.png");

            var enrollmentId = Guid.NewGuid();
            var courseId = Guid.NewGuid();
            var startCourseDate = new DateTime(2021, 9, 1);

            student.AddEnrollment(enrollmentId, courseId, startCourseDate);

            Assert.Throws<EnrollmentNotFoundException>(() => {student.DeleteEnrollment(Guid.NewGuid());});
        }
    }
}