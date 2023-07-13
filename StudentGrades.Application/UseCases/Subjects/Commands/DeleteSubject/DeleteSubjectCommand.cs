using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Subjects.Commands.DeleteSubject
{
    public record DeleteSubjectCommand(Guid SubjectId) : IRequest<SubjectDto>;

    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteSubjectCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject maybeSubject = await
                  _context.Subjects.FindAsync(new object[] { request.SubjectId });

            ValidateSubjectIsNotNull(request, maybeSubject);

            _context.Subjects.Remove(maybeSubject);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SubjectDto>(maybeSubject);
        }

        private static void ValidateSubjectIsNotNull(DeleteSubjectCommand request, Subject maybeSubject)
        {
            if (maybeSubject is null)
            {
                throw new NotFoundException(nameof(Subject), request.SubjectId);
            }
        }
    }
}
