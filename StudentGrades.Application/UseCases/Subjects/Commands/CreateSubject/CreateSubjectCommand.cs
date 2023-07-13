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

namespace StudentGrades.Application.UseCases.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest<SubjectDto>
    {
        public string SubjectName { get; set; }
        public Guid TeacherId { get; set; }
        public virtual ICollection<Guid> Grades { get; set; }
    }

    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSubjectCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            bool areAllExist = request.Grades.All(
               x => _context.Grades.Any(p => p.Id.Equals(x)));

            ValidateAllGradesExist(areAllExist);

            List<Grade> grades = _context.Grades
                .Where(r => request.Grades.Contains(r.Id)).ToList();

            Teacher? maybeTeacher = _context.Teachers.SingleOrDefault(s => s.Id.Equals(request.TeacherId));

            var subject = new Subject
            {
                SubjectName = request.SubjectName,
                Teacher = maybeTeacher,
                Grades = grades
            };

            subject = _context.Subjects.Add(subject).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SubjectDto>(subject);
        }

        private void ValidateAllGradesExist(bool areAllExist)
        {
            if (!areAllExist)
            {
                throw new NotFoundException("Grade does not exist");
            }
        }
    }
}
