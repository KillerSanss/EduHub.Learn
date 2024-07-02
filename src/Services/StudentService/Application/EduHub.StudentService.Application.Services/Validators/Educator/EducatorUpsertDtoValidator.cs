using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;
using ErrorMessages = EduHub.StudentService.Application.Services.Primitives.ErrorMessages;

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
            .MinimumLength(2).WithMessage(ErrorMessages.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessages.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessages.OnlyLetters);
    
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2).WithMessage(ErrorMessages.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessages.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessages.OnlyLetters);
    
        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .MinimumLength(2).WithMessage(ErrorMessages.InvalidLength)
            .MaximumLength(60).WithMessage(ErrorMessages.InvalidLength)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessages.OnlyLetters);

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None).WithMessage(ErrorMessages.DefaultEnum);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessages.PhoneFormat);

        RuleFor(x => x.WorkExperience)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.InvalidData);

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now).WithMessage(ErrorMessages.FutureDate);
    }
}