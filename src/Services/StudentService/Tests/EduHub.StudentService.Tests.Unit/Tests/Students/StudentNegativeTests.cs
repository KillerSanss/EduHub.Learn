using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment;
using EduHub.StudentService.Tests.Unit.Infrastructure.Data;
using EduHub.StudentService.Tests.Unit.Infrastructure.Generators;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.Students
{
    /// <summary>
    /// Негативные unit тесты для сущности Student.
    /// </summary>
    public class StudentNegativeTests
    {
        private readonly Faker _faker = new();

        public static IEnumerable<object[]> TestStudentArgumentExceptionData = TestData.GetStudentArgumentExceptionProperties();
        public static IEnumerable<object[]> TestStudentGuardValidationExceptionData = TestData.GetStudentGuardValidationExceptionProperties();

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается ArgumentException.
        /// </summary>
        /// <param name="surname">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="houseNumber">Номер дома.</param>
        [Theory]
        [MemberData(nameof(TestStudentArgumentExceptionData))]
        public void Add_Properties_ThrowArgumentException(string surname, string name, string patronymic, string city, string street, int houseNumber)
        {
            // Arrange
            var id = _faker.Random.Guid();
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var action = () => new Student(
                id,
                new FullName(surname, name, patronymic),
                gender,
                birthDate,
                email,
                phone,
                new FullAddress(city, street, houseNumber),
                avatar);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается GuardValidationException.
        /// </summary>
        /// <param name="gender">Гендер.</param>
        /// <param name="birthDate">День рождения.</param>
        /// <param name="avatar">Аватар.</param>
        [Theory]
        [MemberData(nameof(TestStudentGuardValidationExceptionData))]
        public void Add_Properties_ThrowGuardValidationException(Gender gender, DateTime birthDate, string avatar)
        {
            // Arrange
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));

            // Act
            var action = () => new Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            action.Should().Throw<GuardValidationException>();
        }

        /// <summary>
        /// Проверка, что метод AddEnrollment сущности Student выбрасывает исключение EnrollmentConflictException.
        /// </summary>
        [Fact]
        public void AddEnrollment_ShouldThrowEnrollmentConflictException()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();
            var enrollment = EnrollmentGenerator.GenerateEnrollment();
            student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);

            // Act
            var action = () => student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);

            // Assert
            action.Should().Throw<EnrollmentConflictException>();
        }

        /// <summary>
        /// Проверка, что метод DeleteEnrollment сущности Student выбрасывает исключение EnrollmentNotFoundException.
        /// </summary>
        [Fact]
        public void DeleteEnrollment_ShouldThrowEnrollmentNotFoundException()
        {
            // Arrange
            var student = StudentGenerator.GenerateStudent();

            // Act
            var action = () => student.DeleteEnrollment(Guid.NewGuid());

            // Assert
            action.Should().Throw<EnrollmentNotFoundException>();
        }
    }
}