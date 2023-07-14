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
