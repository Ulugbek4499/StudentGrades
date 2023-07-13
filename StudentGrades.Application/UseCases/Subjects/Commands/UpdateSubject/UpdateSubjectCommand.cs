﻿using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest<SubjectDto>
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public Guid TeacherId { get; set; }
        public virtual ICollection<Guid> Grades { get; set; }
    }

    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSubjectCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject? maybeSubject = await _context.Subjects
                 .FindAsync(new object[] { request.Id }, cancellationToken);

            ValidateSubjectIsNotNull(request, maybeSubject);

            bool areAllExist = request.Grades.All(
                x => _context.Grades.Any(p => p.Id.Equals(x)));

            ValidateAllGradesExist(areAllExist);

            List<Grade> grades = _context.Grades
                .Where(r => request.Grades.Contains(r.Id)).ToList();

            Teacher? maybeTeacher =
              _context.Teachers.SingleOrDefault(p => p.Id.Equals(request.TeacherId));

            ValidateTeachersAreNotNull(request, maybeTeacher);

            maybeSubject.SubjectName = request.SubjectName;
            maybeSubject.Teacher = maybeTeacher;
            maybeSubject.Grades = grades;

            maybeSubject = _context.Subjects.Update(maybeSubject).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SubjectDto>(maybeSubject);
        }

        private void ValidateTeachersAreNotNull(UpdateSubjectCommand request, Teacher? maybeTeacher)
        {
            if (maybeTeacher == null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }
        }

        private void ValidateAllGradesExist(bool areAllExist)
        {
            if (!areAllExist)
            {
                throw new NotFoundException("Grade does not exist");
            }
        }

        private void ValidateSubjectIsNotNull(UpdateSubjectCommand request, Subject? maybeSubject)
        {
            if (maybeSubject == null)
            {
                throw new AlreadyExistsException();
            }
        }
    }
}
