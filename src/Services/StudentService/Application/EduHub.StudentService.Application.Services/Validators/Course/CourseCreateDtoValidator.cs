using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Course;

/// <summary>
/// Валидация дто создания курса
/// </summary>
public class CourseCreateDtoValidator : AbstractValidator<CreateCourseDto>
{
    private readonly IEducatorRepository _educatorRepository;
    
    public CourseCreateDtoValidator(CreateCourseDto courseDto, IEducatorRepository educatorRepository)
    {
        _educatorRepository = educatorRepository;
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50).WithMessage(string.Format(ErrorMessage.InvalidLength, courseDto.Name));

        RuleFor(x => x.EducatorId)
            .NotEmpty()
            .MustAsync(EducatorExists).WithMessage(string.Format(ErrorMessage.NotFoundError, nameof(Educator), courseDto.EducatorId));
    }
    
    private async Task<bool> EducatorExists(Guid educatorId, CancellationToken cancellationToken)
    {
        return await _educatorRepository.GetByIdAsync(educatorId, cancellationToken) != null;
    }
}

