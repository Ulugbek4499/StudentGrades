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

namespace StudentGrades.Application.UseCases.Students.Commands.DeleteStudent
{
    public record DeleteStudentCommand(Guid studentId) : IRequest<StudentDto>;

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student maybeStudent = await
                  _context.Students.FindAsync(new object[] { request.studentId });

            ValidateDepartmentIsNotNull(request, maybeStudent);

            _context.Students.Remove(maybeStudent);

            await _context.SaveChangesAsync(cancellationToken);


            return _mapper.Map<StudentDto>(maybeStudent);
        }

        private static void ValidateDepartmentIsNotNull(DeleteStudentCommand request, Student maybeStudent)
        {
            if (maybeStudent is null)
            {
                throw new NotFoundException(nameof(Student), request.studentId);
            }
        }
    }
}
