using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Educator;

/// <summary>
/// Валидация дто создания преподавателя
/// </summary>
public class EducatorCreateDtoValidator : AbstractValidator<CreateEducatorDto>
{
    public EducatorCreateDtoValidator(CreateEducatorDto educatorDto)
    {
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength,  educatorDto.Surname))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, educatorDto.Surname))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, educatorDto.Surname));
    
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength, educatorDto.FirstName))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, educatorDto.FirstName))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, educatorDto.FirstName));
    
        RuleFor(x => x.Patronymic)
            .NotEmpty()
            .MinimumLength(2).WithMessage(string.Format(ErrorMessage.InvalidLength, educatorDto.Patronymic))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessage.InvalidLength, educatorDto.Patronymic))
            .Matches(RegexPatterns.LettersPattern).WithMessage(string.Format(ErrorMessage.OnlyLetters, educatorDto.Patronymic));

        RuleFor(x => x.Gender)
            .IsInEnum()
            .NotEqual(Gender.None).WithMessage(string.Format(ErrorMessage.DefaultEnum, nameof(Gender)));
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(RegexPatterns.PhonePattern).WithMessage(ErrorMessage.PhoneFormat);

        RuleFor(x => x.WorkExperience)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessage.InvalidData, educatorDto.WorkExperience));

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now).WithMessage(string.Format(ErrorMessage.FutureDate, educatorDto.StartDate));
    }
}