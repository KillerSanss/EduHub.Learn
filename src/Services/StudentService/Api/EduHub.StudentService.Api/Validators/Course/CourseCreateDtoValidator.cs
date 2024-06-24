using EduHub.StudentService.Application.Services.Dtos.Course;
using FluentValidation;

namespace EduHub.StudentService.Api.Validators.Course;

/// <summary>
/// Валидация дто создания курса
/// </summary>
public class CourseCreateDtoValidator : AbstractValidator<CreateCourseDto>
{
    public CourseCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.EducatorId)
            .NotNull()
            .NotEmpty();
    }
}