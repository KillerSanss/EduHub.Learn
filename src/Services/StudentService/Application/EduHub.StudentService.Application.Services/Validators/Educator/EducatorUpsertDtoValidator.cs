using EduHub.StudentService.Application.Services.Dtos.Educator;
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
            .MinimumLength(2).WithMessage(ErrorMessage.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessage.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessage.OnlyLetters);
    
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2).WithMessage(ErrorMessage.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessage.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessage.OnlyLetters);
    
        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .MinimumLength(2).WithMessage(ErrorMessage.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessage.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessage.OnlyLetters);

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None).WithMessage(ErrorMessage.DefaultEnum);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessage.PhoneFormat);

        RuleFor(x => x.WorkExperience)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage(ErrorMessage.InvalidData);

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now).WithMessage(ErrorMessage.FutureDate);
    }
}