using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для преподавателя
/// </summary>
public class EducatorMappingProfile : Profile
{
    public EducatorMappingProfile()
    {
        CreateMap<Educator, EducatorDto>()
            .ForMember(dest => dest.Surname,
                opt => opt.MapFrom(e => e.FullName.Surname))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(e => e.FullName.FirstName))
            .ForMember(dest => dest.Patronymic,
                opt => opt.MapFrom(e => e.FullName.Patronymic));

        CreateMap<CreateEducatorDto, Educator>()
            .ConstructUsing(dto => new Educator(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.WorkExperience,
                dto.StartDate,
                new Phone(dto.Phone)));

        CreateMap<UpdateEducatorDto, Educator>()
            .ConstructUsing(dto => new Educator(
                dto.Id,
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.WorkExperience,
                dto.StartDate,
                new Phone(dto.Phone)));
    }
}