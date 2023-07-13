using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StudentGrades.Application.UseCases.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty()
             .NotEqual((Guid)default)
             .WithMessage("Id is required.");

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

            RuleFor(u => u.Subjects)
                .ForEach(r => r.NotEqual((Guid)default))
                .WithMessage("Please enter valid subject");
        }
    }
}
