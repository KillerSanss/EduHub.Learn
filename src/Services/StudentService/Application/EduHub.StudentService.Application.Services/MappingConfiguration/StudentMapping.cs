using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для студента
/// </summary>
public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}