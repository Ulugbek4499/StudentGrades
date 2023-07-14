using AutoMapper;
using MediatR;
using StudentGrades.Application.Common.Exceptions;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Teachers.Queries.GetTeacher
{
    public record GetTeacherQuery(Guid TeacherId) : IRequest<TeacherDto>;

    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeacherQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {

            Teacher maybeTeacher = await
                _context.Teachers.FindAsync(new object[] { request.TeacherId });

            ValidateTeacherIsNotNull(request, maybeTeacher);

            return _mapper.Map<TeacherDto>(maybeTeacher);
        }

        private void ValidateTeacherIsNotNull(GetTeacherQuery request, Teacher? maybeTeacher)
        {
            if (maybeTeacher is null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }
        }
    }
}
