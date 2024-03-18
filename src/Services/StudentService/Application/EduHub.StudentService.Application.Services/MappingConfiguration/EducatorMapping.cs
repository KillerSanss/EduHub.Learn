using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для преподавателя
/// </summary>
public class EducatorMapping : Profile
{
    public EducatorMapping()
    {
        CreateMap<Educator, EducatorDto>().ReverseMap();
    }
}