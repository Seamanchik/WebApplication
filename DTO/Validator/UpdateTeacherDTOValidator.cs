using DTO.DTO;
using FluentValidation;

namespace DTO.Validator
{
    public class UpdateTeacherDTOValidator : AbstractValidator<UpdateTeacherDTO>
    {
        public UpdateTeacherDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Некорректный Id преподавателя");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Имя обязательно")
                .MaximumLength(20).WithMessage("Имя не должно превышать 20 символов")
                .Matches("^[а-яА-Яa-zA-Z\\s\\-']+$").WithMessage("Имя должно состоять только из букв, пробелов, дефисов и апострофов");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Фамилия обязательна")
                .MaximumLength(50).WithMessage("Фамилия не должна превышать 50 символов")
                .Matches("^[а-яА-Яa-zA-Z\\s\\-']+$").WithMessage("Фамилия должна состоять только из букв, пробелов, дефисов и апострофов");
        }
    }
}
