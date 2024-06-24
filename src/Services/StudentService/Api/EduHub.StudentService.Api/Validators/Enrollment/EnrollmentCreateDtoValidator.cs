using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Api.Validators.Enrollment;

/// <summary>
/// Валидация дто создания зачисления
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<CreateEnrollmentDto>
{
    public EnrollmentCreateDtoValidator()
    {
        RuleFor(x => x.StartDate)
            .NotNull()
            .LessThan(DateTime.Now);

        RuleFor(x => x.CourseId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.StudentId)
            .NotNull()
            .NotEmpty();
    }
}