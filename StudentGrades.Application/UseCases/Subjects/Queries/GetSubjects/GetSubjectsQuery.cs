using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Subjects.Queries.GetSubjects
{
    public record GetSubjectsQuery : IRequest<SubjectDto[]>;

    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, SubjectDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto[]> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            Subject[] Subjects = await _context.Subjects.ToArrayAsync();

            return _mapper.Map<SubjectDto[]>(Subjects);
        }
    }
}
