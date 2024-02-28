using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment;
using Eduhub.StudentService.Tests.Unit.Generators;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.Student
{
    /// <summary>
    /// Негативные unit тесты для сущности Student.
    /// </summary>
    public class StudentNegativeTests
    {
        private readonly Faker _faker = new();

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается ArgumentException при пустом имени.
        /// </summary>
        [Fact]
        public void Add_NullFullName_ThrowArgumentException()
        {
            // Arrange
            var id = _faker.Random.Guid();
            FullName? fullName = null;
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var action = () => new Eduhub.StudentService.Domain.Entities.Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается GuardValidationException при неверном gender.
        /// </summary>
        [Fact]
        public void Add_NoneGender_ThrowGuardValidationException()
        {
            // Arrange
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.None;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var action = () => new Eduhub.StudentService.Domain.Entities.Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            action.Should().Throw<GuardValidationException>();
        }

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается GuardValidationException при неверном birthDate.
        /// </summary>
        [Fact]
        public void Add_FutureBirthDate_ThrowGuardValidationException()
        {
            // Arrange
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.Male;
            var birthDate = _faker.Date.Future();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var action = () => new Eduhub.StudentService.Domain.Entities.Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            action.Should().Throw<GuardValidationException>();
        }

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается ArgumentException при пустом адресе.
        /// </summary>
        [Fact]
        public void Add_NullFullAddress_ThrowArgumentException()
            // Arrange
        {
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            FullAddress? fullAddress = null;
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var action = () => new Eduhub.StudentService.Domain.Entities.Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        /// <summary>
        /// Проверка, что у сущности Student выбрасывается GuardValidationException при неверном avatar.
        /// </summary>
        [Fact]
        public void Add_InvalidAvatar_ThrowGuardValidationException()
            // Arrange
        {
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = "---";

            // Act
            var action = () => new Eduhub.StudentService.Domain.Entities.Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

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