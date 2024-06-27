using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Course;

/// <summary>
/// Валидация дто создания/обновления курса
/// </summary>
public class CourseUpsertDtoValidator : AbstractValidator<UpsertCourseDto>
{
    public CourseUpsertDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50).WithMessage(ErrorMessage.InvalidLength);

        RuleFor(x => x.EducatorId)
            .NotEmpty();
    }
}

