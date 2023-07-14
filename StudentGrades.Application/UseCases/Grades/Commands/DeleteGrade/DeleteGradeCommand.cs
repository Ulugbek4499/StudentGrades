using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Grades.Commands.DeleteGrade
{
    public record DeleteGradeCommand(Guid gradeId) : IRequest<GradeDto>;

    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, GradeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteGradeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeDto> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            Grade maybeGrade = await
                  _context.Grades.FindAsync(new object[] { request.gradeId });

            ValidateGradeIsNotNull(request, maybeGrade);

            _context.Grades.Remove(maybeGrade);

            await _context.SaveChangesAsync(cancellationToken);


            return _mapper.Map<GradeDto>(maybeGrade);
        }

        private static void ValidateGradeIsNotNull(DeleteGradeCommand request, Grade maybeGrade)
        {
            if (maybeGrade is null)
            {
                throw new NotFoundException(nameof(Grade), request.gradeId);
            }
        }
    }
}
