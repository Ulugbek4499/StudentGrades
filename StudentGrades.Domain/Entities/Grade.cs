using StudentGrades.Domain.Commons;

namespace StudentGrades.Domain.Entities
{
    public class Grade : BaseAuditableEntity
    {
        public int GradeNum { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
