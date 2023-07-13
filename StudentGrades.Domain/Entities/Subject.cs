using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGrades.Domain.Commons;

namespace StudentGrades.Domain.Entities
{
    public class Subject : BaseAuditableEntity
    {
        public string SubjectName { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
