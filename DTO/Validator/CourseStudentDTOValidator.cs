using DTO.DTO;
using FluentValidation;

namespace DTO.Validator;

public class CourseStudentDTOValidator : AbstractValidator<CourseStudentDTO>
{
    public CourseStudentDTOValidator()
    {
        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("Некорректный Id курса");

        RuleFor(x => x.StudentId)
            .GreaterThan(0).WithMessage("Некорректный Id студента");
    }
}
