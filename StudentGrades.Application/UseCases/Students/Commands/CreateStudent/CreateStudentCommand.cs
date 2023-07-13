using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string StudentRegesterNumber { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
                Email = request.Email,
                StudentRegesterNumber = request.StudentRegesterNumber
            };

            student = _context.Students.Add(student).Entity;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StudentDto>(student);
        }
    }
}
