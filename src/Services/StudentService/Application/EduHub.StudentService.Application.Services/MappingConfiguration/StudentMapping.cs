using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для студента
/// </summary>
public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentDto>()
            .ConstructUsing(s => new StudentDto(
                Guid.NewGuid(),
                new FullName(s.FullName.Surname, s.FullName.FirstName, s.FullName.Patronymic),
                s.Gender,
                s.BirthDate,
                new Email(s.Email.Value),
                new FullAddress(s.Address.City, s.Address.Street, s.Address.HouseNumber),
                s.Avatar));
    }
}