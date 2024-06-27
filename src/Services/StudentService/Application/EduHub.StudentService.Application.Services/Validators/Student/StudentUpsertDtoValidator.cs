using EduHub.StudentService.Application.Services.Dtos.Student;
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

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now).WithMessage(ErrorMessage.FutureDate);

        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessage.EmailFormat);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessage.PhoneFormat);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100).WithMessage(ErrorMessage.InvalidLength);

        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100).WithMessage(ErrorMessage.InvalidLength);

        RuleFor(x => x.HouseNumber)
            .NotEmpty()
            .GreaterThan(0).WithMessage(ErrorMessage.InvalidData);

        RuleFor(x => x.Avatar)
            .NotEmpty()
            .Matches(RegexPatterns.AvatarUrlPattern).WithMessage(ErrorMessage.AvatarPattern);
    }
}