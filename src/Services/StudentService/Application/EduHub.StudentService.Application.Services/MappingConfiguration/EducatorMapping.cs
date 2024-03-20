using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для преподавателя
/// </summary>
public class EducatorMapping : Profile
{
    public EducatorMapping()
    {
        CreateMap<Educator, EducatorDto>()
            .ConstructUsing(e => new EducatorDto(
                Guid.NewGuid(),
                new FullName(e.FullName.Surname, e.FullName.FirstName, e.FullName.Patronymic),
                e.Gender,
                e.Phone,
                e.WorkExperience,
                e.StartDate));
    }
}