using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Student;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для студента
/// </summary>
public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentDto>()
            .ConstructUsing(s => new StudentDto(
                s.FullName.Surname,
                s.FullName.FirstName,
                s.FullName.Patronymic,
                s.Gender,
                s.BirthDate,
                s.Email.Value,
                s.Phone.Value,
                s.Address.City,
                s.Address.Street,
                s.Address.HouseNumber,
                s.Avatar));

        CreateMap<StudentDto, Student>()
            .ConstructUsing(dto => new Student(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.BirthDate,
                new Email(dto.Email),
                new Phone(dto.Phone),
                new FullAddress(dto.City, dto.Street, dto.HouseNumber),
                dto.Avatar));

        CreateMap<Student, CreateStudentDto>()
            .ConstructUsing(s => new CreateStudentDto(
                s.FullName.Surname,
                s.FullName.FirstName,
                s.FullName.Patronymic,
                s.Gender,
                s.BirthDate,
                s.Email.Value,
                s.Phone.Value,
                s.Address.City,
                s.Address.Street,
                s.Address.HouseNumber,
                s.Avatar));

        CreateMap<CreateStudentDto, Student>()
            .ConstructUsing(dto => new Student(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.BirthDate,
                new Email(dto.Email),
                new Phone(dto.Phone),
                new FullAddress(dto.City, dto.Street, dto.HouseNumber),
                dto.Avatar));

        CreateMap<Student, UpdateStudentDto>()
            .ConstructUsing(s => new UpdateStudentDto(
                s.Id,
                s.FullName.Surname,
                s.FullName.FirstName,
                s.FullName.Patronymic,
                s.Gender,
                s.BirthDate,
                s.Email.Value,
                s.Phone.Value,
                s.Address.City,
                s.Address.Street,
                s.Address.HouseNumber,
                s.Avatar));

        CreateMap<UpdateStudentDto, Student>()
            .ConstructUsing(dto => new Student(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.BirthDate,
                new Email(dto.Email),
                new Phone(dto.Phone),
                new FullAddress(dto.City, dto.Street, dto.HouseNumber),
                dto.Avatar));
    }
}