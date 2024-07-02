using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Primitives;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Enrollment;

/// <summary>
/// Валидация дто создания/обновления зачисления
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<CreateEnrollmentDto>
{
    public EnrollmentCreateDtoValidator()
    {
        RuleFor(x => x.StartDate)
            .LessThan(DateTime.Now).WithMessage(ErrorMessages.FutureDate);

        RuleFor(x => x.CourseId)
            .NotEmpty();

        RuleFor(x => x.StudentId)
            .NotEmpty();
    }
}