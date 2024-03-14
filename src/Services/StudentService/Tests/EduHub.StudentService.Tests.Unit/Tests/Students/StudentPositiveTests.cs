using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using EduHub.StudentService.Tests.Unit.Infrastructure.Generators;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.Students
{
    /// <summary>
    /// Позитивные unit тесты для сущности Student.
    /// </summary>
    public class StudentPositiveTests
    {
        private readonly Faker _faker = new();

        /// <summary>
        /// Проверка, что у сущности Student корректно создается экземпляр.
        /// </summary>
        [Fact]
        public void Add_Student_ReturnNewStudent()
        {
            // Arrange
            var id = _faker.Random.Guid();
            var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
            var gender = Gender.Male;
            var birthDate = _faker.Date.Past();
            var email = new Email(_faker.Internet.Email());
            var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
            var fullAddress = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100));
            var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

            // Act
            var student = new Student(id, fullName, gender, birthDate, email, phone, fullAddress, avatar);

            // Assert
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
        /// Проверка, что метод Update корректно обновляет экземпляр сущности Student.
        /// </summary>
        [Fact]
        public void Update_Student_ReturnSameStudent()
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
                .Excluding(o => o.Id));
        }
    }
}