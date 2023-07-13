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

namespace StudentGrades.Application.UseCases.Students.Queries.GetStudents
{
    public record GetStudentsQuery : IRequest<StudentDto[]>;

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, StudentDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto[]> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            Student[] Students = await _context.Students.ToArrayAsync();

            return _mapper.Map<StudentDto[]>(Students);
        }
    }
}
