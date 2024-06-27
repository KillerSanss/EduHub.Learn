using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Course;

/// <summary>
/// Валидация дто создания курса
/// </summary>
public class CourseCreateDtoValidator : AbstractValidator<CreateCourseDto>
{
    public CourseCreateDtoValidator(CreateCourseDto courseDto)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50).WithMessage(string.Format(ErrorMessage.InvalidLength, courseDto.Name));

        RuleFor(x => x.EducatorId)
            .NotEmpty();
    }
}

