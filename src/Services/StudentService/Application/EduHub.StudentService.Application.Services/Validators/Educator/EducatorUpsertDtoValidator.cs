using EduHub.StudentService.Application.Services.Dtos.Educator;
using EduHub.StudentService.Application.Services.Primitives;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Educator;

/// <summary>
/// Валидация дто создания/обновления преподавателя
/// </summary>
public class EducatorUpsertDtoValidator : AbstractValidator<UpsertEducatorDto>
{
    public EducatorUpsertDtoValidator()
    {
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MinimumLength(2).WithMessage(Internal.InvalidLength)
            .MaximumLength(60).WithMessage(Internal.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(Internal.OnlyLetters);
    
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2).WithMessage(Internal.InvalidLength)
            .MaximumLength(60).WithMessage(Internal.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(Internal.OnlyLetters);
    
        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .MinimumLength(2).WithMessage(Internal.InvalidLength)
            .MaximumLength(60).WithMessage(Internal.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(Internal.OnlyLetters);

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None).WithMessage(Internal.DefaultEnum);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(Internal.PhoneFormat);

        RuleFor(x => x.WorkExperience)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage(Internal.InvalidData);

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now).WithMessage(Internal.FutureDate);
    }
}