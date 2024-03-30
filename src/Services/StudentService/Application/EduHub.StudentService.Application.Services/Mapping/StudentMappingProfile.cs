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
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Surname, o => o.MapFrom(s => s.FullName.Surname))
            .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FullName.FirstName))
            .ForMember(d => d.Patronymic, o => o.MapFrom(s => s.FullName.Patronymic))
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender))
            .ForMember(d => d.BirthDate, o => o.MapFrom(s => s.BirthDate))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
            .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
            .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
            .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street))
            .ForMember(d => d.HouseNumber, o => o.MapFrom(s => s.Address.HouseNumber))
            .ForMember(d => d.Avatar, o => o.MapFrom(s => s.Avatar));

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