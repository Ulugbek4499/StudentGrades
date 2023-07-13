using FluentValidation;

namespace StudentGrades.Application.UseCases.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty()
             .NotEqual((Guid)default)
             .WithMessage("Grade id is required.");

            RuleFor(p => p.SubjectName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("FirstName is required.");

            RuleFor(t => t.TeacherId).NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("Teacher id is required.");

            RuleFor(u => u.Grades)
                .ForEach(r => r.NotEqual((Guid)default))
                .WithMessage("Please enter valid grade");
        }
    }
}
