using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Students.Queries.GetStudent
{
    public record GetStudentQuery(Guid StudentId) : IRequest<StudentDto>;

    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {

            Student? maybeStudent = await
                _context.Students.FindAsync(request.StudentId);

            ValidateStudentIsNotNull(request, maybeStudent);

            return _mapper.Map<StudentDto>(maybeStudent);
        }

        private void ValidateStudentIsNotNull(GetStudentQuery request, Student? maybeStudent)
        {
            if (maybeStudent is null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }
        }
    }
}
