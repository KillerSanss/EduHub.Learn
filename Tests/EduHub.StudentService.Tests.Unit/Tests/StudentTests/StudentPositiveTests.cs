using Eduhub.StudentService.Tests.Unit.Generators;
using Eduhub.StudentService.Domain.Entities;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.StudentTests
{
    /// <summary>
    /// Позитивные unit тесты для сущности Student.
    /// </summary>
    public class StudentPositiveTests
    {
        private readonly Faker _faker = new Faker();

        /// <summary>
        /// Проверка, что у сущности Student корректно создается экземпляр.
        /// </summary>
        [Fact]
        public void Add_StudentInstance_ReturnStudent()
        {
            // Arrange
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("+373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(new[] {".jpeg", ".png"});

            // Act
            var student = new Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            student.Should().NotBeNull();
            student.Id.Should().Be(id);
            student.FullName.Should().Be(fullName);
            student.Gender.Should().Be(gender);
            student.BirthDate.Should().Be(birthDate);
            student.Email.Should().Be(email);
            student.Phone.Should().Be(phone);
            student.Address.Should().Be(fullAddress);
            student.Avatar.Should().Be(avatar);
        }

        /// <summary>
        /// Проверка, что метод AddEnrollment сущности Student не выбрасывает исключений.
        /// </summary>
        [Fact]
        public void AddEnrollment_ReturnEnrollment()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();
            var enrollment = EnrollmentGenerator.GenerateEnrollment();

            // Act
            Action action = () => student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);

            // Assert
            action.Should()
                .NotThrow();
        }

        /// <summary>
        /// Проверка, что метод DeleteEnrollment сущности Student не выбрасывает исключений.
        /// </summary>
        [Fact]
        public void DeleteEnrollment_ReturnDeletedEnrollment()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();
            var enrollment = EnrollmentGenerator.GenerateEnrollment();

            // Act
            student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);
            Action action = () => student.DeleteEnrollment(enrollment.Id);

            // Assert
            action.Should()
                .NotThrow();
        }

        /// <summary>
        /// Проверка, что метод Update корректно обновляет экземпляр сущности Student.
        /// </summary>
        [Fact]
        public void Update_StudentInstance_UpdatedStudent()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();
            var newStudent = StudentGenerator.GenerateStudent();

            // Act
            student.Update(newStudent.FullName,
                newStudent.Gender,
                newStudent.BirthDate,
                newStudent.Email,
                newStudent.Phone,
                newStudent.Address,
                newStudent.Avatar);

            // Assert
            student.Should().BeEquivalentTo(newStudent, options => options
                .Excluding(o => o.Id)
                .ExcludingNestedObjects());
        }

        /// <summary>
        /// Проверка, что метод GetEnrollments возвращает список зачислений студента.
        /// </summary>
        [Fact]
        public void GetEnrollment_ReturnIEnumerable()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();
            var enrollment1 = EnrollmentGenerator.GenerateEnrollment();
            var enrollment2 = EnrollmentGenerator.GenerateEnrollment();
            student.AddEnrollment(enrollment1.Id, enrollment1.CourseId, enrollment1.StartDate);
            student.AddEnrollment(enrollment2.Id, enrollment2.CourseId, enrollment2.StartDate);

            // Act
            var studentEnrollments = student.GetEnrollments();

            // Arrange
            studentEnrollments.Should().NotBeNull();
        }
    }
}