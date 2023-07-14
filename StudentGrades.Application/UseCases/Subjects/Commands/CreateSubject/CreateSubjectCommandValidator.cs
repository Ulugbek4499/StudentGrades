using FluentValidation;

namespace StudentGrades.Application.UseCases.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(p => p.SubjectName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("FirstName is required.");

            RuleFor(t => t.TeacherId).NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("Teacher id is required.");
        }
    }
}
