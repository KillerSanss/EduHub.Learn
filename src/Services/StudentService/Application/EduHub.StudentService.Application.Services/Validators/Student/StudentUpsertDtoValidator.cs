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

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now).WithMessage(ErrorMessages.FutureDate);

        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessages.EmailFormat);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessages.PhoneFormat);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100).WithMessage(ErrorMessages.InvalidLength);

        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100).WithMessage(ErrorMessages.InvalidLength);

        RuleFor(x => x.HouseNumber)
            .NotEmpty()
            .GreaterThan(0).WithMessage(ErrorMessages.InvalidData);
    }
}