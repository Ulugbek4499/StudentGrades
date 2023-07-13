using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Grades.Commands.UpdateGrade
{
    public class UpdateGradeCommand : IRequest<GradeDto>
    {
        public Guid Id { get; set; }
        public int GradeNum { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }

    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, GradeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGradeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeDto> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {

            Grade maybeGrade = await
                _context.Grades.FindAsync(new object[] { request.Id });

            ValidateGradeIsNotNull(request, maybeGrade);

            Student maybeStudent =
                _context.Students.SingleOrDefault(p => p.Id.Equals(request.StudentId));

            Subject maybeSubject =
               _context.Subjects.SingleOrDefault(p => p.Id.Equals(request.SubjectId));

            ValidateStudentsAreNotNull(request, maybeStudent);

            ValidateSubjectsAreNotNull(request, maybeSubject);

            maybeGrade.GradeNum = request.GradeNum;
            maybeGrade.Student = maybeStudent;
            maybeGrade.Subject = maybeSubject;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GradeDto>(maybeGrade);
        }

        private void ValidateSubjectsAreNotNull(UpdateGradeCommand request, Subject? maybeSubject)
        {
            if (maybeSubject is null)
            {
                throw new NotFoundException(nameof(Subject), request.SubjectId);
            }
        }

        private void ValidateStudentsAreNotNull(UpdateGradeCommand request, Student? maybeStudent)
        {
            if (maybeStudent is null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }
        }

        private void ValidateGradeIsNotNull(UpdateGradeCommand request, Grade? maybeGrade)
        {
            if (maybeGrade == null)
            {
                throw new AlreadyExistsException();
            }
        }
    }
}
