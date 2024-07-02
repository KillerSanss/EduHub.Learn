using EduHub.StudentService.Application.Services.Dtos.Student;
using EduHub.StudentService.Application.Services.Primitives;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Student;

/// <summary>
/// Валидация дто создания/обновления студента
/// </summary>
public class StudentUpsertDtoValidator : AbstractValidator<UpsertStudentDto>
{
    public StudentUpsertDtoValidator()
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

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now).WithMessage(Internal.FutureDate);

        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(RegexPatterns.EmailPattern).WithMessage(Internal.EmailFormat);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(Internal.PhoneFormat);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100).WithMessage(Internal.InvalidLength);

        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100).WithMessage(Internal.InvalidLength);

        RuleFor(x => x.HouseNumber)
            .NotEmpty()
            .GreaterThan(0).WithMessage(Internal.InvalidData);

        RuleFor(x => x.Avatar)
            .NotEmpty()
            .Matches(RegexPatterns.AvatarUrlPattern).WithMessage(Internal.AvatarPattern);
    }
}