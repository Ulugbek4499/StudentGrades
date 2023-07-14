using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand : IRequest<TeacherDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }

    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTeacherCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher maybeTeacher = await _context.Teachers
             .FindAsync(new object[] { request.Id }, cancellationToken);

            ValidateTeacherIsNotNull(request, maybeTeacher);

            maybeTeacher.Name = request.Name;
            maybeTeacher.Email = request.Email;
            maybeTeacher.BirthDate = request.BirthDate;

            maybeTeacher = _context.Teachers.Update(maybeTeacher).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TeacherDto>(maybeTeacher);
        }

        private void ValidateTeacherIsNotNull(UpdateTeacherCommand request, Teacher? maybeTeacher)
        {
            if (maybeTeacher == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }
        }
    }
}
