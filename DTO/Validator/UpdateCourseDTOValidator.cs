using DTO.DTO;
using FluentValidation;

namespace DTO.Validator
{
    public class UpdateCourseDTOValidator : AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Некорректный Id курса");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название курса обязательно")
                .MaximumLength(100).WithMessage("Название не должно превышать 100 символов")
                .Matches("^[а-яА-Яa-zA-Z0-9]+$").WithMessage("Название должно состоять только из букв и цифр");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Описание не должно превышать 500 символов");

            RuleFor(x => x.TeacherId)
                .GreaterThan(0).WithMessage("Некорректный Id преподавателя");
        }
    }
}
