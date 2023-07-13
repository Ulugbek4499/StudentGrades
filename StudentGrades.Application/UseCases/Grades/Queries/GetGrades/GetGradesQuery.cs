using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Grades.Queries.GetGrades
{
    public record GetGradesQuery : IRequest<GradeDto[]>;

    public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, GradeDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGradesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GradeDto[]> Handle(GetGradesQuery request, CancellationToken cancellationToken)
        {
            Grade[] Grades = await _context.Grades.ToArrayAsync();

            return _mapper.Map<GradeDto[]>(Grades);
        }
    }
}
