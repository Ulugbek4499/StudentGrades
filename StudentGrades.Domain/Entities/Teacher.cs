using StudentGrades.Domain.Commons;

namespace StudentGrades.Domain.Entities
{
    public class Teacher : BaseAuditableEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
