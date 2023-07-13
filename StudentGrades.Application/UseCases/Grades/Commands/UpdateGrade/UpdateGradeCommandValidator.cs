using FluentValidation;

namespace StudentGrades.Application.UseCases.Grades.Commands.UpdateGrade
{
    public class UpdateGradeCommandValidator : AbstractValidator<UpdateGradeCommand>
    {
        public UpdateGradeCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty()
              .NotEqual((Guid)default)
               .WithMessage("Grade id is required.");

            RuleFor(t => t.SubjectId).NotEmpty()
                .NotEqual((Guid)default)
                 .WithMessage("Subject id is required.");

            RuleFor(t => t.StudentId).NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("Student id is required.");

            RuleFor(t => t.GradeNum)
                .NotEqual((int)default)
                .GreaterThan(0)
                .WithMessage("Grade is required.");
        }
    }
}
