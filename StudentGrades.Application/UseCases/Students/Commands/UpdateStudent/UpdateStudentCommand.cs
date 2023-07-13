using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<StudentDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string StudentRegesterNumber { get; set; }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student maybeStudent = await
              _context.Students.FindAsync(new object[] { request.Id });

            ValidateStudentIsNotNull(request, maybeStudent);

            maybeStudent.Name = request.Name;
            maybeStudent.Email = request.Email;
            maybeStudent.BirthDate = request.BirthDate;
            maybeStudent.StudentRegesterNumber = request.StudentRegesterNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StudentDto>(maybeStudent);
        }

        private void ValidateStudentIsNotNull(UpdateStudentCommand request, Student? maybeStudent)
        {
            if (maybeStudent == null)
            {
                throw new AlreadyExistsException(nameof(Student), request.Name);
            }
        }
    }
}
