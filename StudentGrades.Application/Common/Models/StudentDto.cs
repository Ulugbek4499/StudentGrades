using Newtonsoft.Json;

namespace StudentGrades.Application.Common.Models
{
    public class StudentDto
    {
        [JsonProperty("student_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<GradeDto>? Grades { get; set; }
    }
}