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

namespace StudentGrades.Application.UseCases.Subjects.Queries.GetSubject
{
    public record GetSubjectQuery(Guid SubjectId) : IRequest<SubjectDto>;

    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubjectQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {

            Subject maybeSubject = await
                _context.Subjects.FindAsync(new object[] { request.SubjectId });

            ValidateSubjectIsNotNull(request, maybeSubject);

            return _mapper.Map<SubjectDto>(maybeSubject);
        }

        private void ValidateSubjectIsNotNull(GetSubjectQuery request, Subject? maybeSubject)
        {
            if (maybeSubject is null)
            {
                throw new NotFoundException(nameof(Subject), request.SubjectId);
            }
        }
    }
}
