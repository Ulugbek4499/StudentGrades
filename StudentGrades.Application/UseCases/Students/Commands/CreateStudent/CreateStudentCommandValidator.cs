using FluentValidation;

namespace StudentGrades.Application.UseCases.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Name is required.");

            RuleFor(t => t.BirthDate)
                .NotEqual((DateTime)default)
                .WithMessage("Birth Date is required.");

            RuleFor(p => p.Email)
               .NotEmpty()
               .MaximumLength(70)
               .WithMessage("Email is required.");
        }
    }
}
