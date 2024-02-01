﻿using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения полного имени
/// </summary>
public class FullName
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Name.
    /// </summary>
    /// <param name="surname">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    public FullName(string surname, string firstName, string patronymic)
    {
        Surname = Guard.Against.Regex(surname, RegexPatterns.LettersPattern);
        FirstName = Guard.Against.Regex(firstName, RegexPatterns.LettersPattern);
        Patronymic = Guard.Against.Regex(patronymic, RegexPatterns.LettersPattern);
    }
}