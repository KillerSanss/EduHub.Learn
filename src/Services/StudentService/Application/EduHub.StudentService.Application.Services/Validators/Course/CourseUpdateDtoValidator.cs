using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Course;

/// <summary>
/// Валидация дто обновления курса
/// </summary>
public class CourseUpdateDtoValidator : AbstractValidator<UpdateCourseDto>
{
    public CourseUpdateDtoValidator(UpdateCourseDto courseDto)
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50).WithMessage(string.Format(ErrorMessage.InvalidLength, courseDto.Name));;

        RuleFor(x => x.EducatorId)
            .NotEmpty();
    }
}