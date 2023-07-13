using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Grades.Queries.GetGrade
{
    public record GetGradeQuery(Guid GradeId) : IRequest<GradeDto>;

    public class GetGradeQueryHandler : IRequestHandler<GetGradeQuery, GradeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGradeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeDto> Handle(GetGradeQuery request, CancellationToken cancellationToken)
        {

            Grade maybeGrade = await
                _context.Grades.FindAsync(new object[] { request.GradeId });

            ValidateGradeIsNotNull(request, maybeGrade);

            return _mapper.Map<GradeDto>(maybeGrade);
        }

        private void ValidateGradeIsNotNull(GetGradeQuery request, Grade? maybeGrade)
        {
            if (maybeGrade is null)
            {
                throw new NotFoundException(nameof(Grade), request.GradeId);
            }
        }
    }
}
