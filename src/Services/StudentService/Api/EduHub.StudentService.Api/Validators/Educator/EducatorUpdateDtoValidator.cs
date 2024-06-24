using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Api.Validators.Educator;

/// <summary>
/// Валидация дто обновления преподавателя
/// </summary>
public class EducatorUpdateDtoValidator : AbstractValidator<UpdateEducatorDto>
{
    public EducatorUpdateDtoValidator()
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
        
        RuleFor(x => x.Phone)
            .NotNull()
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern);

        RuleFor(x => x.WorkExperience)
            .NotNull()
            .NotEmpty()
            .GreaterThan(-1);

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now);
    }
}