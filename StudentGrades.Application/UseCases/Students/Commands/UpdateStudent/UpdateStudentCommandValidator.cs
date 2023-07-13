using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StudentGrades.Application.UseCases.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
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

            RuleFor(p => p.StudentRegesterNumber)
               .NotEmpty()
               .MaximumLength(15)
               .WithMessage("Student Regester Number is required.");
        }
    }
}
