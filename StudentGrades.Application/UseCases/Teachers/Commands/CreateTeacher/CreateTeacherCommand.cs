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

namespace StudentGrades.Application.UseCases.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<TeacherDto>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<Guid> Subjects { get; set; }
    }

    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTeacherCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {

            bool areAllExist = request.Subjects.All(
                x => _context.Subjects.Any(p => p.Id.Equals(x)));

            ValidateAllSubjectsExist(areAllExist);

            List<Subject> subjects = _context.Subjects
                .Where(r => request.Subjects.Contains(r.Id)).ToList();

            var teacher = new Teacher
            {
                Name = request.Name,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Subjects = subjects
            };

            teacher = _context.Teachers.Add(teacher).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TeacherDto>(teacher);
        }

        private void ValidateAllSubjectsExist(bool areAllExist)
        {
            if (!areAllExist)
            {
                throw new NotFoundException("Subject does not exist");
            }
        }
    }
}
