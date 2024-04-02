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
            .ForMember(dest => dest.Surname,
                opt => opt.MapFrom(s => s.FullName.Surname))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(s => s.FullName.FirstName))
            .ForMember(dest => dest.Patronymic,
                opt => opt.MapFrom(s => s.FullName.Patronymic))
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(s => s.Address.City))
            .ForMember(dest => dest.Street,
                opt => opt.MapFrom(s => s.Address.Street))
            .ForMember(dest => dest.HouseNumber,
                opt => opt.MapFrom(s => s.Address.HouseNumber));

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
                dto.Id,
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.BirthDate,
                new Email(dto.Email),
                new Phone(dto.Phone),
                new FullAddress(dto.City, dto.Street, dto.HouseNumber),
                dto.Avatar));
    }
}