using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public record DeleteTeacherCommand(Guid TeacherId) : IRequest<TeacherDto>;

    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteTeacherCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher maybeTeacher = await
                  _context.Teachers.FindAsync(new object[] { request.TeacherId });

            ValidateTeacherIsNotNull(request, maybeTeacher);

            _context.Teachers.Remove(maybeTeacher);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TeacherDto>(maybeTeacher);
        }

        private static void ValidateTeacherIsNotNull(DeleteTeacherCommand request, Teacher maybeTeacher)
        {
            if (maybeTeacher is null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }
        }
    }
}
