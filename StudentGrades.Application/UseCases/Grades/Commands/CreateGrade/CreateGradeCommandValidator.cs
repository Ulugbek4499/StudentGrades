using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            RuleFor(t => t.GradeNum)
                .NotEqual((int)default)
                .GreaterThan(0)
                .WithMessage("Grade is required.");
        }
    }
}
