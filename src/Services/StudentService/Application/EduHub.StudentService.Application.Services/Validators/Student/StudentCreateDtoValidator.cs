using EduHub.StudentService.Application.Services.Dtos.Student;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Student;

/// <summary>
/// Валидация дто создания студента
/// </summary>
public class StudentCreateDtoValidator : AbstractValidator<CreateStudentDto>
{
    public StudentCreateDtoValidator(CreateStudentDto studentDto)
    {
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.Surname))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.Surname))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, studentDto.Surname));
    
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.FirstName))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.FirstName))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, studentDto.FirstName));
    
        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.Patronymic))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.Patronymic))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, studentDto.Patronymic));

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None).WithMessage(string.Format(ErrorMessage.DefaultEnum, nameof(Gender)));

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .LessThan(DateTime.Now).WithMessage(string.Format(ErrorMessage.FutureDate, studentDto.BirthDate));

        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessage.EmailFormat);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessage.PhoneFormat);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(100).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.City));

        RuleFor(x => x.Street)
            .NotEmpty()
            .MaximumLength(100).WithMessage(string.Format(ErrorMessage.InvalidLength, studentDto.Street));

        RuleFor(x => x.HouseNumber)
            .NotEmpty()
            .GreaterThan(0).WithMessage(string.Format(ErrorMessage.InvalidData, studentDto.HouseNumber));

        RuleFor(x => x.Avatar)
            .NotEmpty()
            .Matches(RegexPatterns.AvatarUrlPattern).WithMessage(ErrorMessage.AvatarPattern);
    }
}