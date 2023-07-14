using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.Common.Models
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public Guid TeacherId { get; set; }
        public ICollection<GradeDto>? Grades { get; set; }
    }
}
