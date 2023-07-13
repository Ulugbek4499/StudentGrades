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
        public string SubjectName { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<GradeDto> Grades { get; set; }
    }
}
