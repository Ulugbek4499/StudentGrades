using StudentGrades.Domain.Commons;

namespace StudentGrades.Domain.Entities
{
    public class Student : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
