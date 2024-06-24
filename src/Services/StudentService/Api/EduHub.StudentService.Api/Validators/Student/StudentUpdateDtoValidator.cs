using EduHub.StudentService.Application.Services.Dtos.Student;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Api.Validators.Student;

/// <summary>
/// Валидация дто обновления студента
/// </summary>
public class StudentUpdateDtoValidator : AbstractValidator<UpdateStudentDto>
{
    public StudentUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.LettersPattern);
    
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.LettersPattern);
    
        RuleFor(x => x.Patronymic)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.LettersPattern);

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None);

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now);

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.EmailPattern);
        
        RuleFor(x => x.Phone)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern);

        RuleFor(x => x.City)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        
        RuleFor(x => x.Street)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.HouseNumber)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Avatar)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.AvatarUrlPattern);
    }
}