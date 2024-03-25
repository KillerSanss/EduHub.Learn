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
            .ConstructUsing(e => new EducatorDto(
                Guid.NewGuid(),
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

        CreateMap<Educator, CreateEducatorDto>()
            .ConstructUsing(e => new CreateEducatorDto(
                e.FullName.Surname,
                e.FullName.FirstName,
                e.FullName.Patronymic,
                e.Gender,
                e.Phone.Value,
                e.WorkExperience,
                e.StartDate));

        CreateMap<CreateEducatorDto, Educator>()
            .ConstructUsing(dto => new Educator(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.WorkExperience,
                dto.StartDate,
                new Phone(dto.Phone)));

        CreateMap<Educator, UpdateEducatorDto>()
            .ConstructUsing(e => new UpdateEducatorDto(
                e.Id,
                e.FullName.Surname,
                e.FullName.FirstName,
                e.FullName.Patronymic,
                e.Gender,
                e.Phone.Value,
                e.WorkExperience,
                e.StartDate));

        CreateMap<UpdateEducatorDto, Educator>()
            .ConstructUsing(dto => new Educator(
                Guid.NewGuid(),
                new FullName(dto.Surname, dto.FirstName, dto.Patronymic),
                dto.Gender,
                dto.WorkExperience,
                dto.StartDate,
                new Phone(dto.Phone)));
    }
}