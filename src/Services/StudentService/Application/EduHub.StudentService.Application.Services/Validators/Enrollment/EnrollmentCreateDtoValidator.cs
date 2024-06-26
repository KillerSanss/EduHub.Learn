using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Validations;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validators.Enrollment;

/// <summary>
/// Валидация дто создания зачисления
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<CreateEnrollmentDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    
    public EnrollmentCreateDtoValidator(
        CreateEnrollmentDto enrollmentDto,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        
        RuleFor(x => x.StartDate)
            .NotNull()
            .LessThan(DateTime.Now).WithMessage(string.Format(ErrorMessage.FutureDate, enrollmentDto.StartDate));

        RuleFor(x => x.CourseId)
            .NotEmpty()
            .MustAsync(CourseExist).WithMessage(string.Format(ErrorMessage.NotFoundError, nameof(Course), enrollmentDto.CourseId));

        RuleFor(x => x.StudentId)
            .NotEmpty()
            .MustAsync(StudentExist).WithMessage(string.Format(ErrorMessage.NotFoundError, nameof(Student), enrollmentDto.StudentId));
    }
    
    private async Task<bool> CourseExist(Guid courseId, CancellationToken cancellationToken)
    {
        return await _courseRepository.GetByIdAsync(courseId, cancellationToken) != null;
    }
    
    private async Task<bool> StudentExist(Guid studentId, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetByIdAsync(studentId, cancellationToken) != null;
    }
}