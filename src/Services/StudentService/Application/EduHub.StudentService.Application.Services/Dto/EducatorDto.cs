﻿using Eduhub.StudentService.Domain.Entities.Enums;

namespace EduHub.StudentService.Application.Services.Dto;

/// <summary>
/// Дто преподавателя
/// </summary>
/// <param name="Surname">Фамилия.</param>
/// <param name="FirstName">Имя.</param>
/// <param name="Patronymic">Отчество.</param>
/// <param name="Gender">Гендер.</param>
/// <param name="Phone">Номер телефона.</param>
/// <param name="WorkExperience">Опыт работы.</param>
/// <param name="StartDate">Наачало работы.</param>
public record EducatorDto(
    string Surname,
    string FirstName,
    string Patronymic,
    Gender Gender,
    string Phone,
    int WorkExperience,
    DateTime StartDate);