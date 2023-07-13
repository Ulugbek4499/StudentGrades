using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Application.Common.Models;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.UseCases.Teachers.Queries.GetTeachers
{
    public record GetTeachersQuery : IRequest<TeacherDto[]>;

    public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, TeacherDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeachersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto[]> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            Teacher[] Teachers = await _context.Teachers.ToArrayAsync();

            return _mapper.Map<TeacherDto[]>(Teachers);
        }
    }
}
