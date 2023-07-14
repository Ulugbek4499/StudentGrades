using FluentValidation;

namespace StudentGrades.Application.UseCases.Grades.Commands.CreateGrade
{
    public class CreateGradeCommandValidator : AbstractValidator<CreateGradeCommand>
    {
        public CreateGradeCommandValidator()
        {
            RuleFor(t => t.SubjectId).NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("Subject id is required.");

            RuleFor(t => t.StudentId).NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("Student id is required.");

            RuleFor(t => t.Score)
                .NotEqual((int)default)
                .GreaterThan(0)
                .WithMessage("Grade is required.");
        }
    }
}
