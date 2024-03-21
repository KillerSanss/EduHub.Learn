using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для преподавателя
/// </summary>
public class EducatorProfile : Profile
{
    public EducatorProfile()
    {
        CreateMap<Educator, EducatorDto>()
            .ConstructUsing(e => new EducatorDto(
                e.FullName.Surname,
                e.FullName.FirstName,
                e.FullName.Patronymic,
                e.Gender,
                e.Phone.Value,
                e.WorkExperience,
                e.StartDate));

        CreateMap<EducatorDto, Educator>()
            .ConstructUsing(dto => new Educator(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.WorkExperience,
                dto.StartDate,
                new Phone(dto.Phone)));
    }
}