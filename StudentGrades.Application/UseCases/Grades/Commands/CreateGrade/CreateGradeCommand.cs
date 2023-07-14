using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Grades.Commands.CreateGrade
{
    public class CreateGradeCommand : IRequest<GradeDto>
    {
        public int Score { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }

    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, GradeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateGradeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeDto> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            Subject? maybeSubject = _context.Subjects.SingleOrDefault(s => s.Id.Equals(request.SubjectId));
            Student? maybeStudent = _context.Students.SingleOrDefault(s => s.Id.Equals(request.StudentId));

            ValidateSubjectIsNotNull(request, maybeSubject);
            ValidateStudentIsNotNull(request, maybeStudent);

            var grade = new Grade()
            {
                Score = request.Score,
                Student = maybeStudent,
                Subject = maybeSubject
            };

            grade = _context.Grades.Add(grade).Entity;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GradeDto>(grade);
        }
        private void ValidateStudentIsNotNull(CreateGradeCommand request, Student? maybeStudent)
        {
            if (maybeStudent == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }
        }

        private void ValidateSubjectIsNotNull(CreateGradeCommand request, Subject? maybeSubject)
        {
            if (maybeSubject == null)
            {
                throw new NotFoundException(nameof(Subject), request.SubjectId);
            }
        }
    }
}
