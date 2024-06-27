using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Enrollment;

/// <summary>
/// Валидация дто создания зачисления
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<CreateEnrollmentDto>
{
    public EnrollmentCreateDtoValidator(CreateEnrollmentDto enrollmentDto)
    {
        RuleFor(x => x.StartDate)
            .LessThan(DateTime.Now).WithMessage(string.Format(ErrorMessage.FutureDate, enrollmentDto.StartDate));

        RuleFor(x => x.CourseId)
            .NotEmpty();

        RuleFor(x => x.StudentId)
            .NotEmpty();
    }
}